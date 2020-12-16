module MyProj.ASN1.Compiler


open MyProj.ASN1

let generateTypes (x:AST.ModuleBody) =
    match x with 
    |AST.ModuleBody.Empty -> failwithf ""
    |AST.ModuleBody.Body a -> 
        a
        |> List.iter 
            (fun (x:AST.Assignment) -> 
                match x with 
                |AST.Assignment.TypeAssignment t -> 
                    printfn "%s" t.Identifier 
            )
    
    


