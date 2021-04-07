let reverse lst =
    let rec helper acc lst =
        match lst with
        | [] -> acc
        | h :: t -> helper (h :: acc) t

    helper [] lst

let take lst n =
    let rec loop taken lst n =
        if n = 0 then reverse taken
        else
            match lst with
            | h :: t -> loop (h :: taken) t (n - 1)
            | [] -> reverse taken

    loop [] lst n

let rec slice lst a b =
    let rec cutFront lst n =
        if n = 0 then lst
        else match lst with
                | [] -> []
                | h :: t -> cutFront t (n - 1)

    if a > b then
        slice lst b a
    else
        take <| cutFront lst (a - 1) <| b - a + 1

printfn "%A" <| slice [1; 2; 3; 4; 5] 2 4
printfn "%A" <| slice [1; 2; 3; 4; 5] 4 2
printfn "%A" <| slice [1; 2; 3; 4; 5] 3 3
printfn "%A" <| slice [1; 2; 3; 4; 5] 100 130
