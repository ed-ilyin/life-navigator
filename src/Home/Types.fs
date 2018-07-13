module Home.Types

type Model = {
    cursorTop: int
    cursorLeft: int
    text: string list
}
type KeyPress = {
    key: string
    ctrl: bool
    shift: bool
    alt: bool
    meta: bool
}

type Msg =
    | Failure of System.Exception
    | KeyPress of KeyPress
