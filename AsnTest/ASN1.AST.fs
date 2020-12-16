module MyProj.ASN1.AST



type Exports = unit 
type Imports = unit

type Class = Universal|Application|Private|Empty

type Tag = {
    Class : Class
    ClassNumber : int
}

type BuiltinType =
    |SequenceType of ComponentType list
    |SequenceOfTypeD of SequenceOfType
    |ChoiceType of NamedType list
    |BooleanType
    |IntegerType
    |IA5StringType //NOTE
    |TaggedType of Tag*Type
    |AsciiString
    |OctetString
    //| ...
and SequenceOfType = |TypeD of Type |NamedType of NamedType
and Type = 
    |BuiltinTypeD of BuiltinType
    |ReferencedType of string //This is a simplification check spec for truth
    |ConstrainedType

and NamedType = { Identifier : string; Type : Type }

and ComponentType = 
    |NamedType of NamedType
    |NamedTypeOptional of NamedType
    //|NamedTypeDefault of NamedType*Value

//type SequenceType = ComponentType list

type TypeAssignment = {
    Identifier : string
    Type : Type //TODO this is proablby 
}
type Assignment = 
    |TypeAssignment of TypeAssignment
    //|ValueAssignment
    //|XMLValueAssignment
    //|ValueSetTypeAssignment
    //|ObjectClassAssignment
    //|ObjectAssignment
    //|ObjectSetAssignment
    //|ParameterizedAssignment

type ModuleBody =
    |Empty
    |Body of (Assignment list)

type TagDefault = 
    |Explicit
    |Implicit
    |Automatic
    |Empty

type ExtensionDefault = 
    |ExtensibilityImplied 
    |Empty

type ModuleDefinition =
    {
        TagDefault : TagDefault
        ExtensionDefault : ExtensionDefault
        Identifier : string
        Body : ModuleBody
    }

