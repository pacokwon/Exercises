let rec power f n =
    if n = 0 then (fun x -> x)
    else f >> power f (n - 1)

power (fun x -> x + 1) 10 1 |> printfn "%A"
power (fun x -> x + 1) 11 1 |> printfn "%A"
power (fun x -> x * 2) 10 1 |> printfn "%A"
