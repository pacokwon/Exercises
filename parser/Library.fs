module Library

type Parser<'a> = {
    Parse: string -> Result<'a * string, string>
  }

let runOnInput parser str =
  parser.Parse str

type ParserBuilder () =
  member __.Bind (p, f) = {
      Parse = (fun s ->
        match runOnInput p s with
        | Ok (v, rest) -> runOnInput (f v) rest
        | Error e -> Error e
      )
    }

  member __.Return v = {
      Parse = fun s -> Ok (v, s)
    }

let parser = ParserBuilder ()

let andThen p1 p2 =
  parser {
    let! a = p1
    let! b = p2
    return (a, b)
  }

let (.>>.) = andThen

let map f parser = {
    Parse = (fun s ->
      match runOnInput parser s with
      | Ok (v, rest) -> Ok (f v, rest)
      | Error e -> Error e
    )
  }

let (|>>) p f = map f p

let rec sequence parsers =
  match parsers with
  | hd :: tl ->
    parser {
      let! h = hd
      let! t = sequence tl
      return (h :: t)
    }
  | [] ->
    parser { return [] }

let orElse p1 p2 = {
    Parse = (fun s ->
      match runOnInput p1 s with
      | Ok (v, rest) -> Ok (v, rest)
      | Error e -> runOnInput p2 s
    )
  }

let (<|>) = orElse

let rec zeroOrMore p s =
  match runOnInput p s with
  | Error e -> ([], s)
  | Ok (v, s) ->
    let (v', s') = zeroOrMore p s
    v :: v', s'

module Parser =
  let oneChar = {
      Parse = fun s ->
        if System.String.IsNullOrEmpty s then
          Error "No more input."
        else
          Ok (s.[0], s.[1..])
    }

  let char ch = {
      Parse = fun s ->
        if System.String.IsNullOrEmpty s then
          Error "No more input."
        else
          if s.[0] = ch then
            Ok (s.[0], s.[1..])
          else
            Error "Character not found"
    }

  let twoChars =
    parser {
        let! a = oneChar
        let! b = oneChar
        return (a, b)
      }

  let many p = {
      Parse = (fun s -> Ok (zeroOrMore p s))
    }

  let oneOrMore p = parser {
      let! a = p
      let! b = many p
      return a :: b
    }

  let digit = List.map char ['0' .. '9'] |> List.reduce (<|>)

  let number = parser {
      let! digits = oneOrMore digit
      return digits |> (List.toArray >> System.String >> int)
    }
