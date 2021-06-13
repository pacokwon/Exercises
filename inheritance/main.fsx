type IMammal =
  abstract MakeSound: unit -> unit
  abstract Breathe: unit -> unit

type IWingedAnimal =
  abstract Fly: unit -> unit
  abstract Breathe: unit -> unit

type Bat () =
  interface IMammal with
    member __.MakeSound () = printfn "bat!"
    member __.Breathe () = printfn "mammal breathe"

  interface IWingedAnimal with
    member __.Fly () = printfn "bat flies!"
    member __.Breathe () = printfn "wingedanimal breathe"

let b1 = Bat ()
(b1 :> IMammal).Breathe ()
