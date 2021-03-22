let prob6 a b =
    let rec count_all cur ubound count =
        if cur > ubound then count
        else
            let satisfies = (cur % 7 = 0) && (cur % 5 <> 0)
            count_all (cur + 1) ubound (count + (if satisfies then 1 else 0))
    if a > b || b < 0 then -1
    else count_all a b 0
