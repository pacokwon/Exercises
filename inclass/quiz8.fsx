let myfunc lst =
    let rec loop sum cnt = function
        | Some n :: tail -> loop (sum + n) (cnt + 1) tail
        | None :: tail -> loop sum cnt tail
        | [] -> if cnt = 0 then -1 else sum / cnt

    loop 0 0 lst
