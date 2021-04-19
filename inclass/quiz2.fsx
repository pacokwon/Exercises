let myfunc (a: int32) (b: int32) =
    let sub = int64 a - int64 b
    let sub' = a - b

    if sub = int64 sub' then sub' else 0
