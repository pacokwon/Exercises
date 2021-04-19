let myfunc key value table =
    if Map.containsKey key table then table
    else Map.add key value table

let m = Map.add 42 "abc" Map.empty
myfunc 42 "xxx" m |> printfn "%A"
myfunc 41 "xxx" m |> printfn "%A"
