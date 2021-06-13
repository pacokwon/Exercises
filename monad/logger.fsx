type LoggableInteger = {
  Value: int
  Log: string list
}

type LoggerBuilder () =
  member __.Bind (m, f) =
    let result = f m.Value
    { Value = result.Value; Log = m.Log @ result.Log }

  member __.Return (m) =
    { Value = m; Log = [] }

let logger = LoggerBuilder ()

logger {
  let! x = { Value = 1; Log = ["one"] }
  let! y = { Value = 2; Log = ["two"] }
  let! z = { Value = x + y; Log = ["two"] }
  return z * z
} |> printfn "%A"
