module MyProj.Decoder.BER


open System

///https://docs.oracle.com/cd/E19476-01/821-0510/def-basic-encoding-rules.html

//https://stackoverflow.com/questions/42827939/asn-1-ber-handling-tag-number-31-or-higher

//https://docs.oracle.com/cd/E19476-01/821-0510/def-basic-encoding-rules.html

module Bit = 
    ///Gets if bit is set, 0 is rightmost
    let get (x:byte) index = x &&& (1uy <<< index) <> 0uy   
    let set (x:byte) index = x ||| (1uy <<< index)      

type BerTypeClass = 
    ///The type is native to ASN.1
    |Universal
    ///The type is only valid for one specific application
    |ApplicationSpecific
    ///Meaning of this type depends on the context (such as within a sequence, set or choice)
    |ContextSpecific
    ///Defined in private specifications
    |Private


type BerType = {
    TypeClass : BerTypeClass
    ///true = Primitive = The contents octets directly encode the element value.
    ///false = Constructed = The contents octets contain 0, 1, or more element encodings.
    IsPrimitive : bool
    ///https://en.wikipedia.org/wiki/X.690#BER_encoding
    TypeValue : int
}

let readByte (s:System.IO.Stream) = 
    let b = s.ReadByte()
    if b > -1 then Some (byte b)
    else None

let readByteOrFail (s:System.IO.Stream) = 
    readByte s 
    |> function 
        |Some s -> s 
        |None -> 
            failwithf "Expected byte, but got end of stream at position %i" s.Position

let readBerType (s:System.IO.Stream) =
    //Read type
    let berTypeByte = readByteOrFail s
    
    let bitA = Bit.get berTypeByte (8-1)
    let bitB = Bit.get berTypeByte (8-2)

    let berType = 
        match bitA, bitB with
        |false, false -> BerTypeClass.Universal
        |false, true -> BerTypeClass.ApplicationSpecific
        |true, false -> BerTypeClass.ContextSpecific
        |true, true -> BerTypeClass.Private

    let isPrimitive = Bit.get berTypeByte (8-3) |> not
    
    let typeValue = 31uy &&& berTypeByte
    let berTypeValue = 
        if typeValue = 31uy then 
            //Read bytes until we get one where first bit is NOT set
            let mutable isDone = false
            let data = 
                [|
                    while isDone = false do
                        let incValue = readByteOrFail s
                        let hasMore = Bit.get incValue (8-1)
                        let value = incValue &&& 127uy
                        yield value
                        if hasMore |> not then isDone <- true
                |]

            data
            |> Array.fold 
                (fun (i,v) x -> 
                    let shift = ((data.Length - 1 - i) * 7)
                    let value = int (int x <<< shift)
                    (i+1, v+value)
                ) 
                (0,0)
            |> snd
        else
            int typeValue
    {
        TypeClass = berType
        IsPrimitive = isPrimitive
        TypeValue = berTypeValue
    }

type BerValue = 
    |Primitive of byte array
    |Constructed of BerElement array

and BerElement = {
    BerType : BerType
    Length : uint32
    Value : BerValue
}



let readBerLength (s:System.IO.Stream) = 
    let berLengthByte = readByteOrFail s
    let lengthIsLarge = Bit.get berLengthByte (8-1)
    //Length can be variable apparently... not supported yet
    let berLength = 
        if lengthIsLarge then
            let lengthBytes = int (berLengthByte &&& 127uy)
            if lengthBytes > 4 then failwithf "Only support uint32"
            let l = Array.init lengthBytes (fun _ -> readByteOrFail s)
            
            l
            |> Array.fold 
                (fun (i,v) x -> 
                    let shift = ((lengthBytes - 1 - i) * 8)
                    let value = uint32 (uint32 x <<< shift)
                    (i+1, v+value)
                ) 
                (0,0u)
            |> snd
        else
            uint32 berLengthByte
    berLength



let rec readElement (s:System.IO.Stream) =
    let berType = readBerType s
    let berLength = readBerLength s
    if berLength > uint32 Int32.MaxValue then failwithf "int limitation of %i reached with %i" Int32.MaxValue berLength
    
    let limitedBerLength = int berLength
    let berValue = 
        if berType.IsPrimitive then
            let value = Array.zeroCreate limitedBerLength
            let read = s.Read(value, 0, limitedBerLength)
            if read <> limitedBerLength then failwithf "Failed to read value, only read %i bytes, expected %i bytes" read berLength

            BerValue.Primitive value
        else
            //readElements until eos
            let startPos = s.Position
            let a = 
                [|
                    while s.Position - startPos < int64 limitedBerLength do
                        yield readElement s
                |]
            
            BerValue.Constructed a
        

    {
        BerType = berType
        Length = berLength
        Value = berValue
    } 



    
////INTEGER
//readElement (System.IO.MemoryStream([|0x85;0x01;0x03|] |> Array.map byte))

////OCTETET STRING
//readElement (System.IO.MemoryStream([|0x04;0x05;0x48;0x65;0x6C;0x6C;0x6F|] |> Array.map byte))

//let byteStr (str:string) = 
//    str.Split([|' '|])
//    |> Array.map (fun x -> Byte.Parse(x, System.Globalization.NumberStyles.HexNumber))


//readElement (System.IO.MemoryStream(byteStr "60 16 02 01 03 04 07 63 6E 3D 74 65 73 74 80 08 70 61 73 73 77 6F 72 64" |> Array.map byte))





//let test() = 
//    let f = System.IO.File.OpenRead("C:\Projects\ASN1\AsnTest\AsnTest\sample-DataInterChange-1.ber")

//    //printfn "%i" f.Position

//    //readBerType f


//    readElement f
//    |> printfn "%A" 

    
//let test2 () =
//    let f = System.IO.File.OpenRead("c:\Projects\ASN1\AsnTest\AsnTest\cdr\CDSWEEPSWEQA20447")

//    let el = readElement f

    

//    ()
    

