module Global
open Fable.Import.Browser
open Fable.Core.JsInterop

type Page =
  | Home
  | About

let toHash page =
  match page with
  | About -> "#about"
  | Home -> "#home"
