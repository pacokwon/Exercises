type Utility () =
  static let rand = System.Random ()
  static member RandomSleep () =
    rand.Next (1, 10) |> System.Threading.Thread.Sleep

type MessageBasedCounter () =
  static let updateState (count, sum) msg =
    let newSum = sum + msg
    let newCount = count + 1
    printfn "Count is: %i. Sum is: %i" newCount newSum

    Utility.RandomSleep ()

    (newCount, newSum)

  static let agent = MailboxProcessor.Start (fun inbox ->
    let rec messageLoop oldState = async {
        let! msg = inbox.Receive ()
        printfn "%d received" msg
        let newState = updateState oldState msg
        return! messageLoop newState
      }

    messageLoop (0, 0)
  )

  static member Add i = agent.Post i

let makeCountingTask addFunc taskId = async {
    let name = sprintf "Task %i" taskId
    for i in [1..3] do
      addFunc i
  }

let task = makeCountingTask MessageBasedCounter.Add 1
Async.RunSynchronously task

// let example =
//   [1 .. 5]
//     |> List.map (fun i -> makeCountingTask MessageBasedCounter.Add i)
//     |> Async.Parallel
//     |> Async.RunSynchronously
//     |> ignore
