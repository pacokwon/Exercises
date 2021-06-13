[<EntryPoint>] // This line is essential for a program as it defines the main entry point of this program.
let main argv =
    let folded = Stream.take Stream.fibonacci 5 |> Stream.fold (+) 0
    let filtered = Stream.toList <| (Stream.fibonacci |> Stream.filter (fun x -> x % 2 = 0)) <| 10
    printfn "%A" filtered
    0 // DON't touch this; this is an integer exit code meaning successful termination.
