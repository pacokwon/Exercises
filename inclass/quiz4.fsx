let myfunc (n: uint32) =
    let rec loop count acc =
        if count = n then acc
        else loop <| count + 1u <| acc + "."

    loop 0u ""

myfunc 2u |> printfn "%A"
myfunc 0u |> printfn "%A"
myfunc 10u |> printfn "%A"
