type Shape =
    | Circle of float
    | Square of float
    | Triangle of float * float * float

let myfunc = function
    | Circle r -> System.Math.PI * r * r
    | Square s -> s * s
    | Triangle (a, b, c) ->
        let s = (a + b + c) / 2.
        sqrt (s * (s - a) * (s - b) * (s - c))
