module Home.State

open Elmish
open Types

let node name note fold children = {
    name = name
    note = note
    fold = fold
    children = children
}

let init () : Model * Cmd<Msg> =
    {   nodes =
            Map.ofList [
                "ed", node "Ed Ilyin" "entrepreneur" true [ "ed-root" ]
                "ed-root", node "Home" "beginning" true [ "ed-tags" ]
                "ed-tags", node "Tags" "place for all tags" true
                    [ "ed-tag1"; "ed-tag2" ]
                "ed-tag1", node "Tag One" "one of the tags" true []
                "ed-tag2", node "Tag Two with very very very long description." "second of the tags" true []
            ]
        focus = "ed"
    }, Cmd.none

let update msg model : Model * Cmd<Msg> =
    match msg with
    | Failure _ -> model, Cmd.none
