let countLetter (s1: string) (s2: string) =
    let s1Length = s1.Length
    let s2Length = s2.Length

    let rec loop index count =
        if index + s2Length > s1Length then
            count
        elif s1.[index..(index + s2Length - 1)] = s2 then
            loop (index + 1) (count + 1UL)
        else
            loop (index + 1) count

    if s1 = "" || s2 = "" then
        0UL
    else
        loop 0 0UL

countLetter "foobar fo foo" "fo" |> printfn "%A"
countLetter "foobar fo foo" "" |> printfn "%A"
countLetter "" "fo" |> printfn "%A"
countLetter "fo" "foobar fo foo" |> printfn "%A"
