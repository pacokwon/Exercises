open Library

[<EntryPoint>] // This line is essential for a program as it defines the main entry point of this program.
let main argv =
  let src = "b"
  let strAB = Parser.char 'a' .>>. Parser.char 'b'

  // printfn "%A" (runOnInput (oneOrMore <| Parser.char 'a') src)
  printfn "%A" (runOnInput Parser.digit "1234")
  printfn "%A" (runOnInput Parser.number "001234")
  0 // DON't touch this; this is an integer exit code meaning successful termination.
