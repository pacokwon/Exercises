let computeSum (set: Set<Set<int>>) =
  Set.fold (fun sum inner ->
    sum + (Set.fold (+) 0 inner)
  ) 0 set

let s1 = Set.empty.Add(1).Add(2)
let s2 = Set.empty.Add(4).Add(3)
let s3 = Set.empty.Add(6).Add(5)

let acc = Set.empty.Add(s1).Add(s2).Add(s3)

computeSum acc |> printfn "%A"
