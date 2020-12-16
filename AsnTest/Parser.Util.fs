module MyProj.ParserUtil

open FParsec

let test p str =
    match run p str with
    | Success(result, _, _)   -> printfn "Success: %A" result
    | Failure(errorMsg, a, b) -> printfn "Failure: %s" errorMsg


    
               