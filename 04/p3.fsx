let take lst n =
    let rec reverse acc lst =
        match lst with
        | [] -> acc
        | h :: t -> reverse (h :: acc) t

    let rec loop taken lst n =
        if n = 0 then reverse [] taken
        else
            match lst with
            | h :: t -> loop (h :: taken) t (n - 1)
            | [] -> reverse [] taken

    loop [] lst n

printfn "%A" (take [1; 2; 3; 4] 2)
printfn "%A" (take [1; 2; 3; 4] 6)
printfn "%A" (take [] 6)
printfn "%A" (take [1; 2; 3; 4] 0)
