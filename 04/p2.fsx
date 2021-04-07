let getSmallest lst =
    let rec loop s = function
        | [] -> s
        | h :: t when h < s -> loop h t
        | _ :: t -> loop s t

    match lst with
        | [] -> None
        | h :: t -> loop h t |> Some
