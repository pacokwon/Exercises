let myfunc lst =
    let rec lastButOne = function
        | [] | _ :: [] -> failwith "Shouldn't reach here"
        | t1 :: t2 :: [] -> t1
        | h :: t -> lastButOne t

    match lst with
    | [] | _ :: [] -> failwith "List empty or singleton!"
    | _ -> lastButOne lst

// myfunc [] |> printfn "%A"
// myfunc [1] |> printfn "%A"
myfunc [1; 2; 3] |> printfn "%A"
myfunc [1; 2] |> printfn "%A"
