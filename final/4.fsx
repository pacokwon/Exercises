type LazyBinarySearchTree =
  | Empty
  | Node of left: Lazy<LazyBinarySearchTree>
          * value: int
          * right: Lazy<LazyBinarySearchTree>

// Problem 4 - a
let rec add elt tree =
  match tree with
  | Empty -> Node (lazy Empty, elt, lazy Empty)
  | Node (left, value, right) ->
    // go to the left
    if elt < value then
      Node (lazy (add <| elt <| left.Force ()), value, right)
    else
      Node (left, value, lazy (add <| elt <| right.Force ()))

// let tree1 = add 42 Empty
// printfn "%A" tree1
// let tree2 = add 10 tree1
// printfn "%A" tree2

// Problem 4 - b
let rec exists elt tree =
  match tree with
  | Empty -> false
  | Node (left, value, right) ->
    printfn "%A evaluated" value
    if elt = value then true
    elif elt < value then exists <| elt <| left.Force ()
    else exists <| elt <| right.Force ()

let tree = [3; 1; 5; 7; 2] |> List.fold (fun tree elt -> add elt tree) Empty

// exists 3 tree |> printfn "%A"
// exists 4 tree |> printfn "%A"
exists 2 tree |> printfn "%A"
