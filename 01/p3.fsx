(*
Write a function prob3 that takes in three floating point numbers a, b, and c,
and returns a bigger root of the quadratic formula (in a floating point number):
[ax^2 + bx + c = 0] . If there is only one root, then the function returns the
root. If there is a case where we cannot determine one or two roots in the
range of real numbers, the function should return nan, which is a special
floating point number representing "Not a Number".
*)

let prob3 a b c =
    let det a b c = b * b - 4 * a * c
    let hasRoot a b c = det a b c >= 0
    let biggerRoot a b c = (-b + sqrt det (a b c)) / (2 * a)

    if hasRoot a b c then biggerRoot a b c
    else nan
