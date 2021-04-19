let average lst =
    let rec sumUntilEmpty (sum, cnt) = function
        | n :: rest -> sumUntilEmpty (sum + n, cnt + 1) rest
        | [] -> float sum / float cnt

    sumUntilEmpty (0, 0) lst

average [1; 3; 5] |> printfn "%A"
average [5] |> printfn "%A"
average [] |> printfn "%A" // nan
