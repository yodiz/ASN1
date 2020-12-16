#if COMPILED
module MyProj.ASN1.Parser
#else
#r """c:\Users\Mikael\.nuget\packages\fparsec\1.0.3\lib\netstandard1.6\FParsecCS.dll"""
#r """c:\Users\Mikael\.nuget\packages\fparsec\1.0.3\lib\netstandard1.6\FParsec.dll"""
#endif

//https://docs.microsoft.com/en-us/windows/desktop/seccertenroll/about-constructed-types

//https://www.itu.int/ITU-T/studygroups/com17/languages/X.680-0207.pdf

open FParsec
open MyProj.ASN1


let myws<'a> : Parser<unit,'a> = 
    (
        (pstring "--" .>> skipRestOfLine false |>> ignore)
        <|> (FParsec.CharParsers.anyOf [|' '; '\t'; '\r'; '\n'|] |>> ignore)
    )
    |> many
    |>> ignore
    <??> "whitespace"
    

let ws = myws (*spaces*)
let identifier =
    let isIdentifierFirstChar c = isLetter c || c = '_'
    let isIdentifierChar c = isLetter c || isDigit c || c = '_' || c = '-'

    many1Satisfy2L isIdentifierFirstChar isIdentifierChar "identifier"
    .>> ws 

        


let pType, pTypeRef = createParserForwardedToRef<AST.Type, unit>()


let pNamedType = 
    identifier .>>. pType
    |>> (fun (a,b) -> { AST.NamedType.Identifier = a; AST.NamedType.Type=b })

let pTypeAssignment = 
    pNamedType .>>. (pstringCI "OPTIONAL" |>> (fun x -> ()) |> opt)
    |>> (fun (a,optional) -> 
            match optional with 
            |Some () -> AST.ComponentType.NamedTypeOptional a
            |None -> AST.ComponentType.NamedType a
        )


let pSequence =
    pstringCI "SEQUENCE"
    .>> ws .>> pstringCI "{" .>> ws
    >>. (sepEndBy (pTypeAssignment) (pchar ',' .>> ws))
    .>> ws .>> pstringCI "}" .>> ws


let pChoice = 
    pstringCI "CHOICE" .>> ws .>> pstringCI "{" .>> ws
    >>. (sepEndBy pNamedType (pchar ',' .>> ws))
    .>> ws .>> pstringCI "}" .>> ws 


let pSequenceOfType = 
    pstringCI "SEQUENCE OF" .>> ws >>. 
    (
            (pType |>> (fun x -> AST.SequenceOfType.TypeD x))
        <|> (pNamedType |>> (fun x -> AST.SequenceOfType.NamedType x))
    )
    .>> ws
    
let pTagOptional = 
    //[APPLICATION 169]
    let pClass = 
        pstringCI "Application" |>> (fun _ -> AST.Class.Application) 
        <|> (pstringCI "Universal" |>> (fun _ -> AST.Class.Universal))
        <|> (pstringCI "Private" |>> (fun _ -> AST.Class.Private))
        |> opt

    pstring "[" .>> ws >>. pClass .>> ws .>>. pint32 .>> ws .>> pstring "]" .>> ws
    |>> (fun (c,id) -> { AST.Tag.Class = (c |> function |Some s -> s |None -> AST.Class.Empty) ; AST.Tag.ClassNumber = id })
    |> opt
    

    //pstring "test"

let pBuiltInType = 
      (
            (pstringCI "INTEGER" >>% AST.BuiltinType.IntegerType)
        <|> (pstringCI "BOOLEAN" >>% AST.BuiltinType.BooleanType)
        <|> (pstringCI "IA5String" |>> (fun _ -> AST.BuiltinType.IA5StringType))
        <|> (pstringCI "AsciiString" |>> (fun _ -> AST.BuiltinType.AsciiString))
        <|> (pstringCI "OCTET STRING" |>> (fun _ -> AST.BuiltinType.OctetString))            
        <|> (pChoice |>> (fun x -> AST.BuiltinType.ChoiceType x))
        <|> (pSequenceOfType |>> (fun x -> AST.BuiltinType.SequenceOfTypeD x))
        <|> (pSequence |>> (fun x -> AST.BuiltinType.SequenceType x))
      )
      .>> ws
    //|>> (fun (a,b) -> (match a with |Some a -> ASL.BuiltinType.TaggedType (a,b) |None -> b) |> ASL.Type.Builtin)    

pTypeRef := 
    pTagOptional
    .>>.
    (pBuiltInType |>> (fun x -> AST.Type.BuiltinTypeD x) <|> (identifier |>> (fun x -> AST.Type.ReferencedType x)) .>> ws)
    |>> (fun (tag,a) ->
            match tag with
            |Some s -> 
                AST.Type.BuiltinTypeD (AST.BuiltinType.TaggedType (s, a))
            |None -> a
        )

let pAssignment =    
    let start = identifier .>> pstring "::=" .>> ws
    pipe2 start (pType)
        (fun name def -> 
            AST.Assignment.TypeAssignment
                { AST.TypeAssignment.Identifier = name; 
                  AST.TypeAssignment.Type = def
                })


let pTagDefault = 
    opt (
            pstringCI "EXPLICIT TAGS" .>> ws |>> (fun x -> AST.TagDefault.Explicit)
            <|> (pstringCI "IMPLICIT TAGS" .>> ws |>> (fun x -> AST.TagDefault.Implicit))
            <|> (pstringCI "AUTOMATIC TAGS" .>> ws |>> (fun x -> AST.TagDefault.Automatic))
        )
    |>> function |Some s -> s |None -> AST.TagDefault.Empty


let pExtensionDefault = 
    opt (
            pstringCI "EXTENSIBILITY IMPLIED " .>> ws |>> (fun x -> AST.ExtensionDefault.ExtensibilityImplied)
        )
    |>> function |Some s -> s |None -> AST.ExtensionDefault.Empty


let pModuleDefinition = 
    ws >>. identifier
    .>> pstringCI "DEFINITIONS" .>> ws
    .>>. pTagDefault .>>. pExtensionDefault .>> ws
    .>> pstring "::=" .>> ws    
    .>> pstringCI "BEGIN" .>> ws
    .>>. manyTill pAssignment (pstringCI "END")
    .>> ws .>> eof
    |>> (fun (((a,d),(c)),b) -> 
            { 
                AST.ModuleDefinition.Identifier = a; 
                AST.ModuleDefinition.ExtensionDefault = c;
                AST.ModuleDefinition.TagDefault = d;
                AST.ModuleDefinition.Body = (AST.ModuleBody.Body b) 
            })





