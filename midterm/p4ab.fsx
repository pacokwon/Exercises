type Color =
    | Red
    | Green
    | Blue

let unique lst =
    let rec uniqueHelper lst acc =
        match lst with
        | color :: tail  ->
            if List.contains color acc then
                uniqueHelper tail acc
            else
                uniqueHelper tail (color :: acc)
        | [] -> List.rev acc

    uniqueHelper lst []

let extract i j lst =
    (List.skip i lst) |> List.take (j - i + 1)


unique [Green; Green; Red; Red; Green]|> printfn "%A"
unique [Green; Red; Green; Blue; Red]|> printfn "%A"

extract 3 4 [Red; Green; Blue; Red; Green; Blue] |> printfn "%A"
extract 3 3 [Red; Green; Blue; Red; Green; Blue] |> printfn "%A"
extract 4 5 [Red; Green; Blue; Red; Green; Blue] |> printfn "%A"
