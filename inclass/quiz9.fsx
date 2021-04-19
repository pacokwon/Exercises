let myfunc reduction lst =
    let rec reduce acc = function
        | [] -> acc
        | h :: t -> reduce (reduction acc h) t

    match lst with
    | [] | _ :: [] -> failwith "List is empty or singleton!"
    | h :: t -> reduce h t

myfunc (+) [1; 2; 3] |> printfn "%A"
myfunc (+) [1; 2] |> printfn "%A"
