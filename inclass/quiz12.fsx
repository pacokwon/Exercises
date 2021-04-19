let myfunc a b func =
    let rec loop a b =
        if a > b then ()
        else
        func a
        loop (a + 1) b

    loop a b

let x = ref 0
myfunc 1 10 (fun n -> x := !x + n)
printfn "%d" !x
