let pair (x: int) (y: int) m =
    if m = 0 then x
    else y

let myFst (p: int -> int) = p 0
let mySnd (p: int -> int) = p 1
