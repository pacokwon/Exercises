let rec concat a b =
    match a with
    | [] -> b
    | hd :: tl -> hd :: (concat tl b)

concat [1; 2; 3] [4; 5; 6] |> printfn "%A"
concat [] [4; 5; 6] |> printfn "%A"
