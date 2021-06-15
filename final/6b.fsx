let stringToCharArray (s: string) = Seq.toArray s

let rotateLeft n s =
  let rotateOnce s =
    let arr = stringToCharArray s
    Array.concat [|arr.[1..]; [|arr.[0]|]|] |> System.String

  let rec loop n s =
    if n = 0 then s
    else loop (n - 1) (rotateOnce s)

  loop n s

rotateLeft 5 "abcde" |> printfn "%A"
