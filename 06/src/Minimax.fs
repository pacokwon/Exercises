namespace CS220

/// Minimax strategy.
type MinimaxStrategy () =
  inherit AI ()
    override __.NextMove player board =
      let getall idx acc elt =
        idx :: acc

      let folder idx acc elt =
        match elt with
        | EmptySlot -> idx :: acc
        | _ -> acc

      let rec getScore currentPlayer (board: Board) =
        let emptyIdx = board.Fold folder []

        if List.isEmpty emptyIdx then
          match board.CheckWinner () with
          | None -> (0, 0)
          | Some m when m = player -> (0, 1) // when player wins
          | _ -> (0, -1) // when player loses
        else

        let scores = List.map (fun idx ->
          let newBoard = board.Copy ()
          newBoard.Mark idx currentPlayer |> ignore;
          (getScore <| Marker.getOpponent currentPlayer <| newBoard) |> snd) emptyIdx

        let desiredScore = scores |> (if currentPlayer = player then List.max else List.min)
        match List.tryFindIndex (fun score -> score = desiredScore) scores with
        | Some idx -> (emptyIdx.[idx], desiredScore)
        | None -> failwith "Should not happen"

      let (idx, score) = getScore player board
      idx
