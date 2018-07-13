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

let canvas = document.createElement "canvas"
let canvasContext = canvas?getContext "2d"

let textWidth (text: string) : float =
    do canvasContext?font <- "16px Times"
    let measurement = canvasContext?measureText text
    !!measurement?width
