let safeDiv a b =
  if b = 0 then None
  else Some (a / b)

let bind (x, f) =
  match x with
    | None -> None
    | Some m -> f m

let a, b, c, d, e = 240, 2, 2, 5, 3
let ret x = Some x

// (((a / b) / c) / d) / e
let safeResult = bind (safeDiv a b, fun r ->
  bind (safeDiv r c, fun r ->
    bind (safeDiv r d, fun r ->
      bind (safeDiv r e, fun r ->
        ret r
      )
    )
  )
)

let nativeSafeResult = safeDiv a b |> Option.bind (fun r ->
  safeDiv r c |> Option.bind (fun r ->
    safeDiv r d |> Option.bind (fun r ->
      safeDiv r e |> Option.bind (fun r ->
        ret r
      )
    )
  )
)

nativeSafeResult |> printfn "%A"
