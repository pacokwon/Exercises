type Line = StraightLine of a: int * b: int

let mirrorX = function
  | StraightLine (a, b) -> StraightLine (-a, -b)

let mirrorY = function
  | StraightLine (a, b) -> StraightLine (-a, b)
