// only for positive integers
let countDigits (n: int) =
  let rec loop n =
    if n = 0 then 0
    else 1 + loop (n / 10)

  loop n

countDigits 10 |> printfn "%d"
countDigits 1234 |> printfn "%d"
countDigits 1 |> printfn "%d"
