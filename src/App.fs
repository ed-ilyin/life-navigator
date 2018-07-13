module LifeNavigator.View
open Elmish
open Elmish.Browser
open Elmish.Debug
open Elmish.HMR
open Elmish.React
open Fable.Helpers.React
open State

let root model dispatch = div [] [ str "привет" ]

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
