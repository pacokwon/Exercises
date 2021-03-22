let prob5 m n =
    let rec range_sum cur upper_bound sum =
        if cur > upper_bound then sum
        else range_sum (cur + 1) upper_bound (cur + sum)

    if n < 0 then -1
    else range_sum m (m + n) 0
