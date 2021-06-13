type SimpleLoggerBuilder () =
  member __.Bind (m, f) =
    printfn "%d bound!" m
    f m
  member __.Return (m) =
    printfn "Returning %d" m
    m

let slog = SimpleLoggerBuilder ()

slog {
    let! x = 3
    let! y = 4
    let! z = 5
    return z * z
  }
