let hanoi a b n =
    let rec trace from by dest n =
        if n = 1 then
            [(from, dest)]
        else
            trace from dest by (n - 1) @
            trace from by dest 1 @
            trace by from dest (n - 1)

    trace a (6 - a - b) b n

hanoi 1 3 3 |> printfn "%A"
