let pickFirstThree l =
    match l with
    | a :: b :: c :: _ -> [a; b; c]
    | _ -> failwith "Need to have more then three elements"

// pickFirstThree [] |> printfn "%A" // error!
// pickFirstThree [1] |> printfn "%A" // error!
// pickFirstThree [1; 2] |> printfn "%A" // error!
pickFirstThree [1; 2; 3] |> printfn "%A"
pickFirstThree [1; 2; 3; 4] |> printfn "%A"
pickFirstThree [1; 2; 3; 4; 5] |> printfn "%A"
