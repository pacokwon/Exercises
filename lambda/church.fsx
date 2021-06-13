let church (n: int) =
  let rec iterApp f n x =
    if n <= 0 then x
    else f (iterApp f (n - 1) x)
  fun f -> fun x -> iterApp f n x

let churchToInt ch = ch (fun n -> n + 1) 0
let succ = fun n -> fun m -> fun f -> fun x -> m f (n f x)

let n = church 2
n |> churchToInt |> printfn "%d"
