let splitWords (str: string) =
  System.Text.RegularExpressions.Regex.Split (str, @"\s+")

let findLongest s =
  let words = splitWords s
  Array.reduce (fun (acc: string) (curr: string) ->
    if acc.Length < curr.Length then curr
    else acc
  ) words

findLongest "foo barr baz Fsadfa" |> printfn "%s"
