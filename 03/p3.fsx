type AMPM =
  | AM
  | PM

// these are called "Record" types
type Time = {
  Hours: int
  Minutes: int
  AMPM: AMPM
}

let isEarly t1 t2 =
    match (t1, t2) with
    | ({ AMPM = AM }, { AMPM = PM }) -> true
    | ({ AMPM = PM }, { AMPM = AM }) -> false
    | ({ Hours = h1; Minutes = m1 }, { Hours = h2; Minutes = m2 }) ->
        if h1 < h2 then true
        elif h1 > h2 then false
        else m1 < m2
