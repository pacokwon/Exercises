let removeOdd lst =
    let rec loop = function
        | [] -> []
        | h :: t when h % 2 = 0 -> h :: loop t
        | h :: t -> loop t

    loop lst
