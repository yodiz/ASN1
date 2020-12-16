// Learn more about F# at http://fsharp.org

open System

let parseFile() =
    use f = System.IO.File.OpenRead("CDSWEEPSWEQA20447")
    let e = MyProj.Decoder.BER.readElement f

    let obj = MyProj.Decoder.BER.readBer ``TAP-0311``.DataInterChange.ASN1 e
    let interchange : ``TAP-0311``.DataInterChange = downcast obj
    interchange

let profile() = 
    for i = 0 to 10 do
        parseFile() |> ignore


let dump() = 
    parseFile() 
    |> printfn "%A"

    System.Console.ReadKey() |> ignore

[<EntryPoint>]
let main argv =
    profile()

    //dump()
    0 // return an integer exit code
