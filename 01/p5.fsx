(*
Define a function prob5 that returns the number of days in a specific month
of a specific year (in Gregorian calendar). The function takes as input two
integers year and month, and returns the number of days of the specific year
and the month. The function returns -1 for any error cases. As in prob4. The
signature of the function should look as val prob5: int -> int -> int.
*)

let prob5 year month =
    let is_leap_year year =
        year % 400 = 0 || (year % 100 <> 0 && year % 4 = 0)

    match month with
    | 2 -> if is_leap_year year then 29 else 28
    | 1 | 3 | 5 | 7 | 8 | 10 | 12 -> 31
    | 4 | 6 | 9 | 11 -> 30
    | _ -> -1
