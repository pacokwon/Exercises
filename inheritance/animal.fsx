[<AbstractClass>]
type Animal () =
  let mutable x = 0
  let mutable y = 0
  abstract Breathe: unit -> unit
  member __.Move dx dy =
    x <- x + dx
    y <- y + dy

[<AbstractClass>]
type Mammal () =
  inherit Animal ()
  abstract MakeSound: unit -> unit

type Dog () =
  inherit Mammal ()
  member __.Run () = printfn "Dog runs"
  override __.MakeSound () = printfn "Bark Bark!"
  override __.Breathe () = printfn "Dog breathe"
