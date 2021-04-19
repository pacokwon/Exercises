type Color =
  | Red
  | Green
  | Blue

type Stats = {
    TotalNumReds: int
    TotalNumGreens: int
    TotalNumBlues: int
}

let initialStat = {
    TotalNumReds = 0
    TotalNumGreens = 0
    TotalNumBlues = 0
}

let computeStats lst =
    let rec loop st = function
        | Red :: tl ->
            loop { st with TotalNumReds = st.TotalNumReds + 1 } tl
        | Green :: tl ->
            loop { st with TotalNumGreens = st.TotalNumGreens + 1 } tl
        | Blue :: tl ->
            loop { st with TotalNumBlues = st.TotalNumBlues + 1 } tl
        | [] -> st

    loop initialStat lst

let mostPopularColors lst =
    let stats = computeStats lst

    let results =
        [ (Red, stats.TotalNumReds)
          (Green, stats.TotalNumGreens)
          (Blue, stats.TotalNumBlues) ]

    results
    |> List.sortByDescending snd
    |> List.head
    |> fun ((_, max)) ->
        results |> List.filter (fun (_, n) -> n = max) |> List.map fst

[Blue; Blue; Blue; Green; Green; Green; Red] |> mostPopularColors |> printfn "%A"
