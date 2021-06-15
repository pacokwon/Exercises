type ILocatable =
  abstract member X: int with get, set
  abstract member Y: int with get, set

type IMovable =
  abstract member MoveX: int -> unit
  abstract member MoveY: int -> unit

type Car (x, y) =
  let mutable x = x
  let mutable y = y

  interface ILocatable with
    member __.X with get() = x and set(v) = x <- v
    member __.Y with get() = y and set(v) = y <- v

  interface IMovable with
    member __.MoveX n = x <- x + n
    member __.MoveY n = y <- y + n

type Truck (x, y) =
  inherit Car (x, y)

let truck = Truck (4, 2) :> IMovable
truck.MoveX 42

// printfn "%d %d" truck.X truck.Y
