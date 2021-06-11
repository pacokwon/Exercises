module CS220.BoardHelper

let checkWinner (states: SlotState[]) =
  let getEncoded foo =
    match foo with
    | EmptySlot -> 0
    | Marked (O) -> 1
    | Marked (X) -> -1

  let sumHorizontal idx =
    [states.[idx]; states.[idx + 1]; states.[idx + 2]]
    |> List.map getEncoded
    |> List.reduce (+)

  let sumVertical idx =
    [states.[idx]; states.[idx + 3]; states.[idx + 6]]
    |> List.map getEncoded
    |> List.reduce (+)

  let sumMajor =
    [states.[0]; states.[4]; states.[8]]
    |> List.map getEncoded
    |> List.reduce (+)

  let sumMinor =
    [states.[2]; states.[4]; states.[6]]
    |> List.map getEncoded
    |> List.reduce (+)

  [sumHorizontal 0; sumHorizontal 3; sumHorizontal 6; sumVertical 0; sumVertical 1; sumVertical 2; sumMajor; sumMinor]
  |> List.fold (fun acc sum ->
    if acc <> None then acc else
    match sum with
    | 3 -> Some O
    | -3 -> Some X
    | _ -> None
  ) None

let isDraw states =
  let isFull =
    Array.fold (
      fun full state ->
        if not full then full else
        match state with
        | EmptySlot -> false
        | _ -> true
    ) true states

  if not isFull then false else
  match checkWinner states with
  | None -> true
  | _ -> false
