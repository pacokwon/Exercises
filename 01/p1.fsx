// Define a procedure prob1 that takes three numbers (int) as arguments
// and returns the sum of the squares of the two large numbers.
// If there is any error in processing the inputs, e.g., integer overflows,
// then the function should return -1.

let prob1 a b c =
    let checkOF (x: uint64) = x <> uint64 (int x)
    let square x = uint64 x * uint64 x
    let a1 = max a b |> square
    let a2 = min a b |> max c |> square

    if checkOF a1 || checkOF a2 || checkOF (a1 + a2) then -1
    else a1 + a2 |> int
