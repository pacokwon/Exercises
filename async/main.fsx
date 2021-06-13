open System

[
  async {
    Console.WriteLine "do"
  }
  async {
    Console.WriteLine "something"
  }
  async {
    Console.WriteLine "foo"
  }
  async {
    Console.WriteLine "bar"
  }
] |> Async.Parallel |> Async.RunSynchronously
