let prob4 n =
    let rec sigma n sum =
        if n = 0 then sum
        else sigma (n - 1) (sum + n)

    if n < 0 then -1
    else sigma n 0

printfn "%d" (prob4 10)
