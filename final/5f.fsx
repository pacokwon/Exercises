type Queue<'T> () =
  let mutable elts: 'T list = []

  member __.Add elt = elts <- elts @ [elt]
  member __.Get () =
    match elts with
    | [] -> failwith "Queue empty"
    | hd :: tl ->
      elts <- tl
      hd
