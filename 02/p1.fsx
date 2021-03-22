let prob1 n =
    let rec harmonic num sum =
        match num with
        | num when num <= 0 -> nan
        | 1 -> float 1 + sum
        | num -> harmonic (num - 1) (1. / (float num) + sum)
    harmonic n 0.
