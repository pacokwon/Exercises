type IntTree =
    | Node of left: IntTree * int * right: IntTree
    | Empty

let readUnique tree =
    let rec readUniqueHelper tree =
        match tree with
        | Empty -> []
        | Node (left, num, right) -> readUniqueHelper left @ [num] @ readUniqueHelper right

    readUniqueHelper tree
    |> Set.ofList
    |> Set.toList
    |> List.sort

let structurallyEquiv tree1 tree2 =
    let rec equiv tree1 tree2 =
        match tree1, tree2 with
        | Empty, Empty -> true
        | (Node (l1, n1, r1), Node (l2, n2, r2)) ->
            (equiv l1 l2) && (equiv r1 r2)
        | _, _ -> false

    equiv tree1 tree2

Node (Node (Empty, 3, Empty), 1, Node (Empty, 3, Empty)) |> readUnique |> printfn "%A"
Node (Empty, 1, Node (Empty, 1, Empty)) |> readUnique |> printfn "%A"

let tree3 = Node (Node (Node (Empty, 4, Empty), 2, Empty), 1, Node (Empty, 3, Empty))
let tree4 = Node (Node (Node (Empty, 1, Empty), 3, Empty), 2, Node (Empty, 4, Empty))
structurallyEquiv tree3 tree4 |> printfn "%A"
