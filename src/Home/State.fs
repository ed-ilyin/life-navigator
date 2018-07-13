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
        match keyPress with
        | { key = "h" } ->
            { model with cursorLeft = model.cursorLeft - 1 }
        | { key = "j" } ->
            { model with cursorTop = model.cursorTop + 1 }
        | { key = "k" } ->
            { model with cursorTop = model.cursorTop - 1 }
        | { key = "l" } ->
            { model with cursorLeft = model.cursorLeft + 1 }
        | _ -> model
        , string keyPress |> exn |> Failure |> Cmd.ofMsg
