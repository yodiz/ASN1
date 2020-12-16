module MyProj.ASN1.Compiler


open MyProj.ASN1
open MyProj.ASN1
open MyProj.ASN1.AST
open System


let forceFirstUppercase (s:string) =  
    if s.Length > 0 && System.Char.IsLower(s.Chars 0) then 
        s.Substring(0,1).ToUpper() + s.Substring(1)
    else s


type OptionalOption = |Optional|Required
type Primitive = |AsciiString|Boolean|IA5String|Integer|OctetString
let isPrimitive v = 
    ["AsciiString"; "Boolean"; "IA5String"; "Integer"; "OctetString"]
    |> List.contains v



type OutputBaseType = 
    ///MyProj.ASN1.ASNType.Primitive(byte[])
    |PrimitiveClass of string
    ///F# Union
    |Union of (string*OutputType) list
    ///F# Record
    |Record of (string*OutputType*OptionalOption) list
    ///F# List
    |List of OutputType

and OutputType = 
    |BaseType of OutputBaseType
    |AliasReference of Alias
    |TaggedType of AST.Tag*OutputType

and Alias(str) = 
    let mutable ref = None
    member x.Name = str
    member x.Get() = ref |> Option.get
    member x.Validate(typeList:(string*OutputType) list) = 
        let refType = 
            if isPrimitive str then 
                OutputType.BaseType (PrimitiveClass str) 
            else
                let a = typeList |> List.tryFind (fun (x,a) -> x = str)
                        |> function |Some s -> s |None -> failwithf "no type definition for '%s' " str
                a |> snd

        let rec validateOutputType (t:OutputType) = 
            match t with 
            |AliasReference r -> r.Validate typeList
            |BaseType (PrimitiveClass str) -> ()
            |BaseType (Union str) -> str |> List.iter (fun (_,x) -> validateOutputType x)
            |BaseType (Record str) -> str |> List.iter (fun (_,x,_) -> validateOutputType x)
            |BaseType (List str) -> validateOutputType str
            |TaggedType (tag, output) -> validateOutputType output

        ref <- Some refType
        ()



let getTypeRefName ofType = 
    match ofType with 
    |OutputType.AliasReference a -> a.Name
    |OutputType.BaseType (OutputBaseType.PrimitiveClass s) -> s
    |a -> failwithf "Unsupported %A" a

let rec getBaseType ofType = 
    match ofType with 
    |OutputType.AliasReference a -> getBaseType (a.Get())
    |OutputType.BaseType s -> s
    |OutputType.TaggedType (t, tt) -> getBaseType tt


    
        


let rec getOutputForBuiltIN (bt:AST.BuiltinType) : OutputType = 
    match bt with 
    |AST.BuiltinType.AsciiString -> OutputType.BaseType (OutputBaseType.PrimitiveClass "AsciiString")
    |AST.BuiltinType.BooleanType -> OutputType.BaseType (OutputBaseType.PrimitiveClass "Boolean")
    |AST.BuiltinType.IA5StringType -> OutputType.BaseType (OutputBaseType.PrimitiveClass "IA5String") 
    |AST.BuiltinType.IntegerType -> OutputType.BaseType (OutputBaseType.PrimitiveClass "Integer") 
    |AST.BuiltinType.OctetString -> OutputType.BaseType (OutputBaseType.PrimitiveClass "OctetString") 

    |AST.BuiltinType.ChoiceType c -> 
        OutputType.BaseType (OutputBaseType.Union
            (
                c 
                |> List.map (fun x -> (forceFirstUppercase x.Identifier), getOutputForType x.Type)
            ))

    |AST.BuiltinType.SequenceOfTypeD s ->         
        match s with 
        |AST.SequenceOfType.NamedType nt -> OutputType.BaseType (OutputBaseType.List(getOutputForType nt.Type)) 
        |AST.SequenceOfType.TypeD t -> OutputType.BaseType (OutputBaseType.List(getOutputForType t)) 

    |AST.BuiltinType.SequenceType st -> 
        let a = 
            st
            |> List.map (function   |AST.ComponentType.NamedType t -> (t.Identifier, getOutputForType t.Type, OptionalOption.Required)
                                    |AST.ComponentType.NamedTypeOptional t -> (t.Identifier, getOutputForType t.Type, OptionalOption.Optional)
                        )
        OutputType.BaseType (OutputBaseType.Record a)

    |AST.BuiltinType.TaggedType (tag, tt) -> 
        OutputType.TaggedType (tag, getOutputForType tt)
        


and getOutputForType (t:AST.Type) : OutputType = 
    match t with
    |AST.Type.BuiltinTypeD (bt) -> getOutputForBuiltIN bt
    |AST.Type.ConstrainedType -> failwithf ""
    |AST.Type.ReferencedType name -> 
        OutputType.AliasReference (Alias(name)) 


let generateOutput (a:AST.Assignment list) = 
    let types = 
        a |> List.map (function |AST.Assignment.TypeAssignment t -> t.Identifier, getOutputForType t.Type)

    let rec validate (out:OutputType) types = 
        match out with 
        |OutputType.AliasReference a -> a.Validate types
        |OutputType.TaggedType (tag,t) -> validate t types
        |OutputType.BaseType b -> ()

    //Dereference referenced types
    types
    |> List.iter
        (function 
            |name, t -> validate t types)
    types       
    


let indent n = String.replicate n "    "
  


let tagComment (tags:Tag list) = 
    if tags |> List.isEmpty |> not then
        sprintf 
            "(* [%s] *)" 
            (tags |> List.map (fun x -> sprintf "%s %i" (x.Class.ToString()) x.ClassNumber) |> String.concat ", ")
    else ""

let rec outputOutputType tags id t (sw:System.IO.StreamWriter) =
    let indent = "    "

    match t with 
    |TaggedType (tag, output) -> 
        outputOutputType (tag :: tags) id output sw
    |OutputType.AliasReference alias -> 
        let ofType = alias.Get()
        let baseType = getBaseType ofType

        match baseType with 
        |(OutputBaseType.Record ofType) -> 
            sprintf "type ``%s``%s = { Item : ``%s`` }" id (tagComment tags) alias.Name
            |> sw.WriteLine     
            sprintf "%swith static member ASN1 = createReferenceMeta<``%s``> %s \"%s\" (``%s``.ASN1)"
                indent id
                (match tags with |[] -> "None" |a :: _ -> sprintf "(Some { ClassNumber = %i; Class = %s })" a.ClassNumber (a.Class.ToString()))
                alias.Name
                alias.Name
            |> sw.WriteLine

            sprintf "%s     static member create data : ``%s`` = { Item = data }" 
                indent 
                id
            |> sw.WriteLine


        |(OutputBaseType.PrimitiveClass ofType) -> 
            sprintf "type ``%s``%s = { Item : ``%s``  }" id (tagComment tags) alias.Name
            |> sw.WriteLine     

            sprintf "%swith static member ASN1 = createPrimitiveMeta<``%s``> %s"
                indent id
                (match tags with |[] -> "None" |a :: _ -> sprintf "(Some { ClassNumber = %i; Class = %s })" a.ClassNumber (a.Class.ToString()))
            |> sw.WriteLine
            sprintf "%s     static member create data : ``%s`` = { Item = ``%s``.create data }" 
                indent 
                id
                alias.Name
            |> sw.WriteLine


        |(OutputBaseType.List ofType) -> failwithf "Not supported Lists, alias %s" alias.Name
        |(OutputBaseType.Union ofType) -> failwithf "Not supported Unions, alias %s" alias.Name
                                    

    |OutputType.BaseType (OutputBaseType.PrimitiveClass name)  -> 
        sprintf "type ``%s``%s = { Item : %s }" id (tagComment tags) name
        |> sw.WriteLine 
        sprintf "%swith static member ASN1 = createPrimitiveMeta<``%s``> %s"
            indent id
            (match tags with |[] -> "None" |a :: _ -> sprintf "(Some { ClassNumber = %i; Class = %s })" a.ClassNumber (a.Class.ToString()))
        |> sw.WriteLine
        sprintf "%s     static member create data : ``%s`` = { Item = ``%s``.create data }" 
            indent 
            id
            name
        |> sw.WriteLine

    |OutputType.BaseType (OutputBaseType.List ofType)  ->  
        sprintf "type ``%s``%s = { Items : %s list } " id (tagComment tags) (getTypeRefName ofType)
        |> sw.WriteLine 
        sprintf "%swith static member ASN1 = createSequenceOfMeta<``%s``> %s (``%s``.ASN1)"
            indent id
            (match tags with |[] -> "None" |a :: _ -> sprintf "(Some { ClassNumber = %i; Class = %s })" a.ClassNumber (a.Class.ToString()))
            (getTypeRefName ofType)
        |> sw.WriteLine
        sprintf "%s     static member create data : ``%s`` = { Items = data |> Seq.cast<``%s``> |> Seq.toList }" 
            indent 
            id
            (getTypeRefName ofType)
        |> sw.WriteLine


    |OutputType.BaseType (OutputBaseType.Record props)  ->  
        let propsStr = 
            props 
                |> List.map 
                    (fun (name, t, opt) -> 
                        sprintf "%s%s : %s %s" indent name (getTypeRefName t) (match opt with |OptionalOption.Optional -> "option" |OptionalOption.Required -> "")
                    )
                |> String.concat ";\r\n"

        
        sprintf "" |> sw.WriteLine
        sprintf "type ``%s``%s = {\r\n%s\r\n} " id  (tagComment tags) propsStr
        |> sw.WriteLine 

        sprintf "%swith static member ASN1 = createSequenceMeta<``%s``> %s [%s]"
            indent id
            (match tags with |[] -> "None" |a :: _ -> sprintf "(Some { ClassNumber = %i; Class = %s })" a.ClassNumber (a.Class.ToString()))
            (props |> List.map (fun (a,b,c) -> sprintf "(\"%s\", ``%s``.ASN1, %s)" a (getTypeRefName b) (match c with |OptionalOption.Optional -> "true" |OptionalOption.Required -> "false")) |> String.concat ";" )
        |> sw.WriteLine

    |OutputType.BaseType (OutputBaseType.Union alts)  ->  
        let altsStr = alts |> List.map (fun (n,t) -> sprintf "%s|%s of %s" indent n (getTypeRefName t)) |> String.concat "\r\n"
        sprintf "type ``%s`` %s = \r\n%s" id (tagComment tags) altsStr
        |> sw.WriteLine 

        sprintf "%swith static member ASN1 = createChoiceMeta<``%s``> %s [%s]" 
            indent 
            id
            (match tags with |[] -> "None" |a :: _ -> sprintf "(Some { ClassNumber = %i; Class = %s })" a.ClassNumber (a.Class.ToString()))
            (alts |> List.map (fun (n,t) -> sprintf "\"%s\", ``%s``.ASN1" n n) |> String.concat "; ")
            
        |> sw.WriteLine

    sw.WriteLine()



let generateTypes (astModule:AST.ModuleDefinition) (s:System.IO.Stream) =
    use sw = new System.IO.StreamWriter(s)

    sw.WriteLine (sprintf "// Generated code")

    let ns = sprintf "``%s``" astModule.Identifier

    sw.WriteLine (sprintf "module rec %s" ns)
    sw.WriteLine (sprintf "open MyProj.ASN1.ASNType")

    match astModule.Body with 
    |AST.ModuleBody.Body a -> 
        let output = generateOutput a
        output
        |> List.iter 
            (fun (id, t) -> 
                outputOutputType [] id t sw
            )



    


