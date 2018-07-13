module Home.State

open Elmish
open Types

let init () : Model * Cmd<Msg> =
    {   cursorTop = 0
        cursorLeft = 0
        cursorTopPx = "0px"
        cursorLeftPx = "0px"
        cursorChar = "a"
        text =
            [   "abba babba"
                "piggy miggy"
            ]
    }, Cmd.none

let cursorChar model =
    List.tryItem model.cursorTop model.text
    |> Option.map (fun l ->
        try
        { model with
            cursorLeftPx =
                Seq.take model.cursorLeft l
                |> Array.ofSeq
                |> System.String
                |> Global.textWidth
                |> sprintf "%fpx"
            cursorChar =
                match
                    List.tryItem model.cursorTop model.text
                    |> Option.bind (Seq.tryItem model.cursorLeft)
                    |> Option.defaultValue '!'
                    with ' ' -> "\u00a0" | ch -> string ch
        }
        with _ -> model
    )
    |> Option.defaultValue model

let update msg model : Model * Cmd<Msg> =
    match msg with
    | Failure _ -> model, Cmd.none
    | KeyPress keyPress ->
        match keyPress with
        | { key = "h" } ->
            let c = model.cursorLeft - 1
            { model with
                cursorLeft = c
                // cursorLeftPx = c * 8 |> sprintf "%ipx"
            } |> cursorChar
        | { key = "j" } ->
            let c = model.cursorTop + 1
            { model with
                cursorTop = c
                cursorTopPx= c * 18 |> sprintf "%ipx"
            } |> cursorChar
        | { key = "k" } ->
            let c = model.cursorTop - 1
            { model with
                cursorTop = c
                cursorTopPx= c * 18 |> sprintf "%ipx"
            } |> cursorChar
        | { key = "l" } ->
            let c = model.cursorLeft + 1
            { model with
                cursorLeft = c
                // cursorLeftPx = c * 8 |> sprintf "%ipx"
            } |> cursorChar
        | _ -> model
        , string keyPress |> exn |> Failure |> Cmd.ofMsg
