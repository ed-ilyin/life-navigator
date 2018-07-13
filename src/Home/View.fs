module Home.View

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fable.Import

let root model dispatch =
    div [
        Id "paper"; TabIndex 1.
        // OnKeyPress (printfn "%A")
        OnKeyPress (fun e ->
            KeyPress {
                key = e.key
                ctrl = e.ctrlKey
                shift = e.shiftKey
                alt = e.altKey
                meta = e.metaKey
            } |> dispatch
        )
    ] [
            div [ Id "c" ] [
                List.map (fun s -> div [] [ str s ]) model.text
                |> ofList
                div [ Id "cursor"; Style [ Top "0px"; Left "7px" ] ]
                    [ str "b" ]
            ]
    ]
