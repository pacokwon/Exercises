let rec myfunc a b =
    if a < b then myfunc b a
    elif b = 0 then a
    else myfunc b (a % b)
