module Home.State

open Elmish
open Types

let init () : Model * Cmd<Msg> =
    {   cursorTop = 0
        cursorLeft = 0
        text =
            [   "abba babba"
                "piggy miggy"
            ]
    }, Cmd.none

let update msg model : Model * Cmd<Msg> =
    match msg with
    | Failure _ -> model, Cmd.none
    | KeyPress keyPress ->
        model, string keyPress |> exn |> Failure |> Cmd.ofMsg
