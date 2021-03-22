let prob3 a b =
    let rec gcd a b =
        if b = 0 then
            a
        else
            gcd b (a % b)

    if a < 0 || b < 0 then -1
    else gcd a b
