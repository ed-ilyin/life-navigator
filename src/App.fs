module App.View
open Elmish
open Elmish.Browser
open Elmish.Debug
open Elmish.HMR
open Elmish.React
open Fable.Helpers.React
open Fable.Helpers.React.Props
open State
open Types

let root model dispatch =
    ofList [
        Home.View.root model.home (HomeMsg >> dispatch)
        Option.map (fun e -> div [ Style [ Color "red" ] ] [ str e ])
            model.error
        |> ofOption
    ]

// App
Program.mkProgram init update root
|> Navigation.Program.toNavigable (UrlParser.parseHash pageParser) urlUpdate
//-:cnd:noEmit
#if DEBUG
|> Program.withDebugger
|> Program.withHMR
#endif
//+:cnd:noEmit
|> Program.withReact "app"
|> Program.run
