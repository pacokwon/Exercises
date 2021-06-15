let computeSum (set: Set<Set<int>>) =
  Set.fold (fun sum inner ->
    sum + (Set.fold (+) 0 inner)
  ) 0 set

let s1 = Set.ofList [1;2;3;4]
let s2 = Set.ofList [1;2;3;4]
let s3 = Set.ofList [s1; s2]
computeSum s3 |> printfn "%d"
