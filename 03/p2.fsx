let pair (x: int) (y: int) m : int = m x y

let first p = p (fun x y -> x)

pair 1 2 |> first |> printfn "%A"
pair 2 4 |> first |> printfn "%A"
