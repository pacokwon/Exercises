type ResultWithDebugMessage<'a> = {
  Result: 'a
  DbgMsg: string
}

let inc x = { Result = x + 1; DbgMsg = "incremented" }
let dec x = { Result = x - 1; DbgMsg = "decremented" }

let combine f r =
  let r' = f r.Result
  { r' with DbgMsg = r.DbgMsg + "\n" + r'.DbgMsg }

let id_op = inc >> combine dec

let wrap r = { Result = r; DbgMsg = " " }

inc
>> combine dec
>> combine (fun x -> x * 10 |> wrap)
>> combine dec
<| 10 |> printfn "%A"
