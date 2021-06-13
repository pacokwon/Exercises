open System
open System.Threading
open System.Diagnostics

type Utility () =
  static let rand = Random ()
  static member RandomSleep () =
    let ms = rand.Next (1, 10)
    Thread.Sleep ms

type Counter () =
  static let updateState (count, sum) msg =
    let newSum = sum + msg
    let newCount = count + 1
    printfn "Count i %i. Sum is %i" newCount newSum

    // Utility.RandomSleep ()

    (newCount, newSum)

  static let echoAgent = MailboxProcessor.Start (fun inbox ->
    let rec loop oldState = async {
        let! msg = inbox.Receive ()
        // printfn "Got message: %d" msg
        let newState = updateState oldState msg
        return! loop newState
      }

    loop (0, 0)
  )

  static member Add i = echoAgent.Post i

let makeTask postFunc = async {
    for i in [1 .. 3] do
      postFunc i
  }

[1 .. 5]
  |> List.map (fun i -> makeTask Counter.Add)
  |> Async.Parallel
  |> Async.RunSynchronously
  |> ignore;
