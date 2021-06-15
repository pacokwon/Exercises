type ResultWithCount<'T> = {
  Value: 'T
  Count: int
}

type ResultWithCountBuilder () =
  member __.Bind (m, f) =
    let result = f m.Value
    { Value = result.Value; Count = result.Count + 1 }
  member __.Return (v) =
    { Value = v; Count = 1 }

let rc = ResultWithCountBuilder ()
let mkValue v = { Value = v; Count = 0 }

let foo = rc {
  let! x = mkValue 42
  let! y = mkValue 50
  return x + y
}
