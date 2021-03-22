let isFeasible a b c =
    let rec isFeasibleHelper cur sum =
        if cur > b then
            sum = c
        else
            isFeasibleHelper (cur + 1) (sum + cur) || isFeasibleHelper (cur + 1) (sum - cur)
    if a > b then false
    else isFeasibleHelper (a + 1) a
