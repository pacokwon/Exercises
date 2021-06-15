type Stream<'a> =
    | Nil
    | Cons of 'a * (unit -> Stream<'a>)

let rec fold func accum stream =
  match stream with
  | Nil -> accum
  | Cons (head, tail) ->
      fold <| func <| func accum head <| tail ()

