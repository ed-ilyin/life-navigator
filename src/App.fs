module App.View
open Elmish
open Elmish.Browser
open Elmish.Debug
open Elmish.HMR
open Elmish.React
open Fable.Core
open Fable.Helpers.React
open Fable.Helpers.React.Props
open State
open Types

JsInterop.importAll "./style.styl"

let root model dispatch =
    ofList [
        Option.map (fun e -> div [ Id "error" ] [ str e ]) model.error
        |> ofOption
        Home.View.root model.home (HomeMsg >> dispatch)
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
