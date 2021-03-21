(*
Define a function prob4 that returns the number of days in a month.
The function takes in as input an integer representing a month, and
outputs the number of days. You can assume that February has 28 days.
The function returns -1 for any error cases. For example, if a number
big than 12 is given as input, then the function should return -1.
*)

let prob4 month =
    match month with
    | 2 -> 28
    | 1 | 3 | 5 | 7 | 8 | 10 | 12 -> 31
    | 4 | 6 | 9 | 11 -> 30
    | _ -> -1
