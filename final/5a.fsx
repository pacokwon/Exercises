let mutable x = 42
let inc x = x + 1
let dec x = x - 1
let incJob = async { x <- inc x }
let decJob = async { x <- dec x }

Array.append (Array.create 500 incJob) (Array.create 500 decJob)
|> Async.Parallel
|> Async.RunSynchronously
printfn "%d" x
