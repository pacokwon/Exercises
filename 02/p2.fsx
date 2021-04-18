let prob2 amount =
    let rec count usable currentAmount =
        if currentAmount < 0 then 0
        elif currentAmount = 0 then 1
        else

        let usableList = List.indexed usable |> List.map (function
            | index, _ -> List.skip index usable
        )

        List.map (fun usable ->
            match usable with
            | head :: tail -> count usable (currentAmount - head)
            | [] -> failwith "Shouldn't reach here"
        ) usableList |> List.sum

    if amount < 0 then -1
    else count [500; 100; 50; 10; 1] amount

prob2 50 |> printfn "%A"
