module Stream

type Stream<'a> =
    | Nil
    | Cons of 'a * (unit -> Stream<'a>)

let car stream =
    match stream with
        | Nil -> failwith "Stream Empty!"
        | Cons (head, _) -> head

let cdr stream =
    match stream with
        | Nil -> failwith "Stream Empty!"
        | Cons (_, tail) -> tail ()

let rec take stream n =
    if n = 0 then Nil else
    Cons (car stream, fun () -> take (cdr stream) (n - 1))

let rec fromList = function
    | [] -> Nil
    | head :: tail -> Cons (head, fun () -> (fromList tail))

let rec toList stream cnt =
    if cnt = 0 then [] else
    (car stream) :: (toList (cdr stream) (cnt - 1))

let rec map func = function
    | Nil -> Nil
    | Cons (head, tail) -> Cons (head |> func, fun () -> map <| func <| tail ())

let rec filter func = function
    | Nil -> Nil
    | Cons (head, tail) ->
        if head |> func then Cons (head, fun () -> filter <| func <| tail ())
        else filter <| func <| tail ()

let rec fold func accum = function
    | Nil -> accum
    | Cons (head, tail) ->
        fold <| func <| func accum head <| tail ()

let rec ones = Cons (1, fun () -> ones)

let rec natural = Cons (1, fun () -> map <| (+) 1 <| natural)

let fibonacci =
    let rec fibo a b = Cons (a, fun () -> fibo b (a + b))
    fibo 0 1

let rec seqOnes = Seq.unfold (fun () -> Some (1, ())) ()
let rec seqNatural = Seq.unfold (fun state -> Some (state, state + 1)) 1
