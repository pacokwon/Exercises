let pow (s: string) (n: int32) =
    let rec helper (s: string) (n: int32) (result: string) =
        if n = 0 then result
        elif n < 0 then
            let rev_s = s.ToCharArray() |> Array.rev |> System.String
            helper rev_s -n result
        else
            helper s (n - 1) (result + s)
    helper s n ""
