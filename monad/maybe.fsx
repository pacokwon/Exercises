type MaybeBuilder () =
  member __.Bind (m, f) =
    match m with
    | None -> None
    | Some x -> f x

  member __.Return (x) = Some x

let safeDiv a b =
  if b = 0 then None
  else Some (a / b)

let maybe = MaybeBuilder ()

let a, b, c, d, e = 240, 2, 2, 5, 3
maybe {
  let! r = safeDiv a b
  let! r = safeDiv r c
  let! r = safeDiv r d
  let! r = safeDiv r e
  return r
}
