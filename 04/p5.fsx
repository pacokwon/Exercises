let isPalindrome lst =
    let rec reverse acc = function
        | [] -> acc
        | h :: t -> reverse (h :: acc) t

    let rec loop lst1 lst2 =
        match lst1, lst2 with
        | [], [] -> true
        | (h1 :: t1), (h2 :: t2) when h1 = h2 -> loop t1 t2
        | _ -> false

    loop lst (reverse [] lst)

printfn "%A" (isPalindrome [1; 2; 3; 4])
printfn "%A" (isPalindrome [])
printfn "%A" (isPalindrome [1; 2; 1])
printfn "%A" (isPalindrome [1; 1])
printfn "%A" (isPalindrome [1])
