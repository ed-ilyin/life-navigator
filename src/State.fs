module LifeNavigator.State

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Global
open Types

let pageParser: Parser<Page->Page,Page> =
    oneOf [
        map About (s "about")
        map Home (s "home")
        map Home top
    ]

let urlUpdate (result: Option<Page>) model =
    match result with
    | None ->
        { model with error = Some "Error parsing url" },
            Navigation.modifyUrl (toHash model.currentPage)
    | Some page ->
        { model with currentPage = page }, []

let init result =
  let (home, homeCmd) = Home.State.init()
  let (model, cmd) =
    urlUpdate result {
        currentPage = Home
        home = home
        error = None
    }
  model, Cmd.batch [ cmd
                     Cmd.map HomeMsg homeCmd ]

let update msg model =
  match msg with
  | HomeMsg msg ->
      let (home, homeCmd) = Home.State.update msg model.home
      { model with home = home }, Cmd.map HomeMsg homeCmd
