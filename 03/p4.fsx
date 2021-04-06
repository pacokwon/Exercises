type AMPM =
  | AM
  | PM

// these are called "Record" types
type Time = {
  Hours: int
  Minutes: int
  AMPM: AMPM
}

let addMinutes time minutes =
    let switchAMPM = function
        | AM -> PM
        | PM -> AM

    if (minutes > 0) then
        let extraMinutes = minutes % 60
        let _extraHours = minutes / 60

        let extraHours =
            if (time.Minutes + extraMinutes >= 60) then
                (_extraHours + 1) % 24
            else
                _extraHours % 24

        let ampm =
            if (time.Hours + extraHours >= 24) then
                time.AMPM
            elif (time.Hours + extraHours >= 12) then
                switchAMPM time.AMPM
            else
                time.AMPM

        {
            Hours = (time.Hours + extraHours) % 12
            Minutes = (time.Minutes + extraMinutes) % 60
            AMPM = ampm
        }
    elif (minutes = 0) then
        time
    else
        // both negative
        let _extraMinutes = if (minutes % 60 = 0) then 0 else minutes % 60 + 60
        let _extraHours = if (minutes % 60 = 0) then minutes / 60 else minutes / 60 - 1

        let minutes =
            if (time.Minutes + _extraMinutes >= 60) then
                (time.Minutes + _extraMinutes) % 60
            else
                time.Minutes + _extraMinutes

        let extraHours =
            if (time.Minutes + _extraMinutes >= 60) then
                (_extraHours + 1) % 24
            else
                _extraHours % 24

        let ampm =
            if (time.Hours + extraHours < -12) then
                time.AMPM
            elif (time.Hours + extraHours < 0) then
                switchAMPM time.AMPM
            else
                time.AMPM

        {
            Hours = (time.Hours + extraHours) % 12 + 12
            Minutes = minutes
            AMPM = ampm
        }

printfn "%A" (addMinutes { Hours = 5; Minutes = 30; AMPM = AM } 60);
printfn "%A" (addMinutes { Hours = 5; Minutes = 30; AMPM = AM } 420);
printfn "%A" (addMinutes { Hours = 5; Minutes = 30; AMPM = AM } 1140);

printfn "%A" (addMinutes { Hours = 5; Minutes = 30; AMPM = AM } -60);
printfn "%A" (addMinutes { Hours = 5; Minutes = 30; AMPM = AM } -300);
printfn "%A" (addMinutes { Hours = 5; Minutes = 30; AMPM = AM } -360);
printfn "%A" (addMinutes { Hours = 5; Minutes = 30; AMPM = AM } -1080);
printfn "%A" (addMinutes { Hours = 5; Minutes = 30; AMPM = AM } -1800);
