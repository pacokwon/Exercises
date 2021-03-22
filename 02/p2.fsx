let prob2 amount =
    let rec solve n from =
        if n < 0 then
            0
        elif n = 0 then
            1
        else

        let _ :: allowedCoins = List.scan (fun acc cur -> cur :: acc) [] (List.rev from)
        let sum = List.map (fun allowed -> match allowed with | head :: _ -> solve (n - head) (List.rev allowed)) allowedCoins |> List.sum
        sum

    if amount < 0 then
        -1
    else
        solve amount [1; 10; 50; 100; 500]
