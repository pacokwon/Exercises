type AMPM =
  | AM
  | PM

type Time = {
  Hours: int
  Minutes: int
  AMPM: AMPM
}

let toTimestamp time =
    let start = if time.AMPM = AM then 0 else 720
    start + time.Hours * 60 + time.Minutes

let toTime timestamp =
    {
        AMPM = if timestamp >= 720 then PM else AM;
        Hours = (timestamp % 720) / 60;
        Minutes = timestamp % 60;
    }

let addMinutes t m =
    let timestamp = toTimestamp t
    let added = (timestamp + m) % 1440

    if added < 0 then (added + 1440) else added
    |> toTime

printfn "%A" (addMinutes { Hours = 5; Minutes = 30; AMPM = AM } 60);
printfn "%A" (addMinutes { Hours = 5; Minutes = 30; AMPM = AM } 420);
printfn "%A" (addMinutes { Hours = 5; Minutes = 30; AMPM = AM } 1140);

printfn "%A" (addMinutes { Hours = 5; Minutes = 30; AMPM = AM } -60);
printfn "%A" (addMinutes { Hours = 5; Minutes = 30; AMPM = AM } -300);
printfn "%A" (addMinutes { Hours = 5; Minutes = 30; AMPM = AM } -360);
printfn "%A" (addMinutes { Hours = 5; Minutes = 30; AMPM = AM } -1080);
printfn "%A" (addMinutes { Hours = 5; Minutes = 30; AMPM = AM } -1800);
