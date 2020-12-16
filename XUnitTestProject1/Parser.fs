module ParserTest

open System
open Xunit


// x Decode BER Element(s)
// x Parse ASN.1 file to AST
//      - Validate Reference types
// x Generate Records from AST to .fs File
//      - See if we can remove rec module declaration
// - Generate Function that takes BER-Element and gives Record

open MyProj

let parseFile p file = 
    FParsec.CharParsers.runParserOnFile
        p
        ()
        file
        System.Text.Encoding.UTF8

let parseOrFail p file = 
    parseFile p file 
    |> function
        |FParsec.CharParsers.Success (r,u,p) ->  r
        |FParsec.CharParsers.Failure (e,pe,u) -> failwithf "Parser Error: %s" e

let ensureCanParseFile file = 
    let r = parseFile ASN1.Parser.asn1Module file

    match r with 
    |FParsec.CharParsers.Success (r,u,p) ->  Assert.True(true)
    |FParsec.CharParsers.Failure (e,pe,u) -> Assert.True(false, sprintf "Parser Error: %s" e)    

[<Fact>] 
let ``Can parse Example1`` () = ensureCanParseFile "./TestFiles/asn1/example1.asn1"

[<Fact>] 
let ``Can parse Example2`` () = ensureCanParseFile "./TestFiles/asn1/example2.asn1"

[<Fact>] 
let ``Can parse Tap311`` () = ensureCanParseFile "./TestFiles/asn1/tap311.asn"

[<Fact>] 
let ``Can parse Tap312`` () = ensureCanParseFile "./TestFiles/asn1/TAP_3_12_SPECIFICATION.txt"


[<Fact>] 
let ``Can parse Tap311 mode A`` () = ensureCanParseFile "./TestFiles/asn1/TAP_3_11_SPECIFICATION.txt"


[<Fact>]
let ``Generate file``() = 
    let r = parseOrFail ASN1.Parser.asn1Module "./TestFiles/asn1/tap311.asn"
    printfn "Module: %s" r.Identifier

    let tempFile = System.IO.Path.GetTempFileName()

    use s = System.IO.File.Open(tempFile, System.IO.FileMode.Create)
    MyProj.ASN1.Compiler.generateTypes r s
    ()


//[<Fact>] - Removed of privacy reasons
let ``Can ber-decode CDSWEEPSWEQA20447``() = 
    use f = System.IO.File.OpenRead("./TestFiles/cdr/CDSWEEPSWEQA20447")
    let e = MyProj.Decoder.BER.readElement f

    printfn "%A" e.BerType
    ()


let parseInterchangeFromDisc () =
    use f = System.IO.File.OpenRead("./TestFiles/cdr/CDSWEEPSWEQA20447")
    let e = MyProj.Decoder.BER.readElement f

    let obj = MyProj.Decoder.BER.readBer ``TAP-0311``.DataInterChange.ASN1 e
    let interchange : ``TAP-0311``.DataInterChange = downcast obj
    interchange

//[<Fact>]
let ``Parse CDSWEEPSWEQA20447 to F# type``() = 
    let a = parseInterchangeFromDisc ()
    printfn "%A" a

    match a with 
    |``TAP-0311``.DataInterChange.Notification n -> 
        ()
    |``TAP-0311``.DataInterChange.TransferBatch b -> 

        ()
    ()

//[<Fact>]
let ``Parse CDSWEEPSWEQA20447 to F# type 10 times``() = 
    for i = 0 to 10 do
        parseInterchangeFromDisc () |> ignore
    ()



    //Spara ner 





//test pModuleDefinition """FooProtocol DEFINITIONS ::= 
//BEGIN


//END"""

//test pModuleDefinition """FooProtocol DEFINITIONS ::= BEGIN
//    FooQuestion ::= SEQUENCE {
//            trackingNumber INTEGER,
//            question       IA5String,
//        }    
//END"""

//test pSequence """SEQUENCE {
//            trackingNumber INTEGER,
//            question       IA5String,
//        }    
//"""


//let pModuleBody =
//    many pAssignment
    


//test pModuleBody """FooQuestion ::= SEQUENCE {
//        trackingNumber INTEGER,
//        question       IA5String
//    }
//"""


//let example1Src = System.IO.File.ReadAllText("C:\Projects\ASN1\AsnTest\AsnTest\example1.asn1")
//test pModuleDefinition example1Src

//let example2Src = System.IO.File.ReadAllText("C:\Projects\ASN1\AsnTest\AsnTest\example2.asn1")
//test pModuleDefinition example2Src

//let tap311Src = System.IO.File.ReadAllText("""C:\Projects\ASN1\AsnTest\AsnTest\tap311.asn""")
//test pModuleDefinition tap311Src
