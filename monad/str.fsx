type StringIntBuilder () =
  member __.Bind (m: string, f) =
    let b, i = System.Int32.TryParse m
    match b, i with
    | false, _ -> "Error!"
    | true, v -> f v

  member __.Return (x) = string x

let stringint = new StringIntBuilder ()

let good =
  stringint {
      let! i = "42"
      let! j = "43"
      return i + j
    }

let bad =
  stringint {
      let! i = "42"
      let! j = "xx"
      return i + j
    }

printfn "good = %s" good
printfn "bad = %s" bad
