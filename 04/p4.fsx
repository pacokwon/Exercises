let runLength lst =
    let rec reverse acc = function
        | [] -> acc
        | h :: t -> reverse (h :: acc) t

    let rec loop prev cnt acc lst =
        match lst with
        | [] -> (prev, cnt) :: acc
        | h :: t when prev = h -> loop prev (cnt + 1) acc t
        | h :: t -> loop h 1 ((prev, cnt) :: acc) t

    match lst with
    | [] -> []
    | h :: t -> loop h 1 [] t |> reverse []

printfn "%A" (runLength [ 1; 2; 2; 2; 3; 3 ])
printfn "%A" (runLength [])
printfn "%A" (runLength [ 1; 2; 2; 1; 2; 3; 2; 3 ])
