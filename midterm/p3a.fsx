let rec inc n =
    if n = 0u then 1u
    else inc (n - 1u) + 1u


inc 0u |> printfn "%A"
inc 1u |> printfn "%A"
inc 2u |> printfn "%A"
inc 3u |> printfn "%A"
inc 4u |> printfn "%A"
inc 5u |> printfn "%A"
inc 6u |> printfn "%A"
inc 7u |> printfn "%A"
inc 8u |> printfn "%A"
inc 9u |> printfn "%A"
inc 10u |> printfn "%A"
