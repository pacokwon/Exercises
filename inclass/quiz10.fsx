let myfunc l1 l2 =
    let set1 = set l1
    let set2 = set l2

    Set.intersect set1 set2 |> Set.toList
