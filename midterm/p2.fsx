type MyList<'T> =
    | Cons of 'T * MyList<'T> ref
    | Nil

let mutableAppend (lst: MyList<int32>) (num: int32) =
    let rec mutate lst num =
        match !lst with
        | Cons (head, tail) -> mutate tail num
        | Nil -> lst := Cons (num, ref Nil)

    match lst with
    | Cons (h, t) -> mutate t num |> ignore
    | Nil -> failwith "List is empty!"

    lst

let mylist = Cons (50, ref (Cons (10, ref Nil)))
printfn "%A" (mutableAppend mylist 2)
