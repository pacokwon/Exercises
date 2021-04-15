let rec rotate lst N =
    if N < 0 then
        rotate (List.rev lst) -N |> List.rev
    else
        let length = List.length lst
        List.append (List.skip (length - N) lst) (List.take (length - N) lst)

rotate [1; 2; 3; 4] 1 |> printfn "%A"
rotate [1; 2; 3; 4] -1 |> printfn "%A"
