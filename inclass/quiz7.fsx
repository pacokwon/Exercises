type MyList<'T> =
    | Nil
    | Cons of 'T * MyList<'T>

let myfunc lst =
    let rec loop count = function
        | Nil -> count
        | Cons (h, t) -> loop (count + 1) t

    loop 0 lst

Cons (1, Cons (3, Cons (5, Nil))) |> myfunc |> printfn "%A"
Cons (3, Cons (5, Nil)) |> myfunc |> printfn "%A"
Cons (5, Nil) |> myfunc |> printfn "%A"
Nil |> myfunc |> printfn "%A"
