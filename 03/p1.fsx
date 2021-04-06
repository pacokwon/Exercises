type Shape =
/// A circle of a radius.
| Circle of float
/// A square with a side length.
| Square of float
/// A triangle with side lengths.
| Triangle of float * float * float

let area = function
    | Circle r -> r * r * System.Math.PI
    | Square s -> s * s
    | Triangle (a, b, c) ->
        let s = (a + b + c) / 2.
        sqrt (s * (s - a) * (s - b) * (s - c))
