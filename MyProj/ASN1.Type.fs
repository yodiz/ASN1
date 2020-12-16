module MyProj.ASN1.ASNType



type AsciiString = { value : byte [] } with static member create data = { value = data }
type Boolean = { value : byte [] } with static member create data = { value = data }
type IA5String = { value : byte [] } with static member create data = { value = data }
type Integer = { value : byte [] } with static member create data = { value = data }
type OctetString = { value : byte [] } with static member create data = { value = data }

type Class = Universal|Application|Private
type Tag = {
    Class : Class
    ClassNumber : int
}

type ChoiceOpt= {
    Name : string
    Meta : Meta
    CreateOption : obj -> obj
}

and SequenceOpt = {
    Members : (string*Meta*bool) list
    Create : obj array -> obj
}

and SequenceOfOpt = {
    Meta : Meta
    Create : obj array -> obj
}

and PrimitiveOpt = {
    Create : byte[] -> obj
}

and ReferenceOpt = {
    Name : string
    Meta : Meta
    Create : obj -> obj
}

and BaseType = 
    |Sequence of SequenceOpt
    |Choice of ChoiceOpt list
    |SequenceOf of SequenceOfOpt
    |Primitive of PrimitiveOpt
    |Reference of ReferenceOpt

and Meta = {
    Tag : Tag option
    BaseType : BaseType
}

let createPrimitiveMeta<'a> tag = 
    let ctor = typeof<'a>.GetMethod("create")
    if (ctor = null) then failwithf "Dit not find primitive static 'create' method for %s" typeof<'a>.Name
    
    {
        Tag = tag
        BaseType = BaseType.Primitive { Create = (fun data -> ctor.Invoke(null, [|data|])) }
    }

let createReferenceMeta<'a> tag name meta =    
    let ctor = typeof<'a>.GetMethod("create")
    if (ctor = null) then failwithf "Dit not find primitive static 'create' method for %s" typeof<'a>.Name
    {
        Tag = tag
        BaseType = BaseType.Reference { Name = name; Meta = meta; Create = (fun data -> ctor.Invoke(null, [|data|])) }
    }

let createSequenceMeta<'a> tag members = 
    let ctor = Microsoft.FSharp.Reflection.FSharpValue.PreComputeRecordConstructor(typeof<'a>)
    
    //Make mapper, if field is optiuonal we make it top Some if != null
    let fields = Microsoft.FSharp.Reflection.FSharpType.GetRecordFields(typeof<'a>)


    let someMappers = 
        (fields, members)
        ||> Seq.map2 
            (fun a (_,_,b) -> 
                if b then 
                    let unionCases = Microsoft.FSharp.Reflection.FSharpType.GetUnionCases(a.PropertyType)
                    let someCase = unionCases |> Array.find (fun x -> x.Name = "Some")
                    let someMaker = Microsoft.FSharp.Reflection.FSharpValue.PreComputeUnionConstructor(someCase)
                    (fun x -> if x = null then x else someMaker [|x|])
                else id
            )
        |> Seq.toArray

    let mapSomeValues (o:obj array) = 
        (someMappers,o)
        ||> Array.map2 (fun m o -> m o)
        


    {
        Tag = tag
        BaseType = 
            BaseType.Sequence 
                { 
                    Create = (fun a -> mapSomeValues a |> ctor) 
                    Members = members
                }
    }

let createSequenceOfMeta<'a> tag seqTypeMeta = 
    let ctor = typeof<'a>.GetMethod("create")
    if (ctor = null) then failwithf "Dit not find list static 'create' method for %s" typeof<'a>.Name
    
    {
        Tag = tag
        BaseType = BaseType.SequenceOf { Meta = seqTypeMeta; 
                                         Create = (fun a -> 
                                                        ctor.Invoke(null, [|a|])
                                                            ) }
    }


let createChoiceMeta<'a> tag (options) =
    let t = typeof<'a>
    if Microsoft.FSharp.Reflection.FSharpType.IsUnion t |> not then
        failwithf "Type '%s' was not a union type" (t.ToString())
    let cases = Microsoft.FSharp.Reflection.FSharpType.GetUnionCases(t)

    let cOpts = 
        options
        |> List.map 
            (fun (name,meta) -> 
                let case = cases |> Array.find (fun x -> x.Name = name)
                let cstr = Microsoft.FSharp.Reflection.FSharpValue.PreComputeUnionConstructor(case)
                {
                    Name = name
                    Meta = meta
                    CreateOption = (fun x -> cstr([|x|]))
                }            
            )
    {
        Tag = tag
        BaseType = BaseType.Choice cOpts
    }


