module Home.View

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fable.Import

let children nodes children =
    let rec loop children =
        let node nodeId =
            match Map.tryFind nodeId nodes with
            | Some node ->
                ofList [
                    div [ Class "heading" ] [
                        div [ Class "bullet full" ] []
                        span [] [
                            div [ Class "name"; ContentEditable true ]
                                [ str node.name ]
                            div [ Class "note"; ContentEditable true ]
                                [ str node.note ]
                        ]
                    ]
                    div [ Class "children" ] [
                        loop node.children
                    ]
                ]
            | None -> sprintf "cant find \"%s\"" nodeId |> str
        List.map node children |> ofList
    loop children

let root model dispatch =
    match Map.tryFind model.focus model.nodes with
    | None -> sprintf "нет записи %s" model.focus |> str
    | Some node -> div [ Id "paper" ] [
        h1 [ Class "main name"; ContentEditable true ] [ str node.name ]
        div [ Class "main note"; ContentEditable true ]
            [ str node.note ]
        children model.nodes node.children
    ]
