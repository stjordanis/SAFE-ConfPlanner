module Login.Types

open Infrastructure.Auth
open Global

type LoginState =
| LoggedOut
| LoggedIn of UserData

type Model =
  {
    State : LoginState
    Login : Login
    ErrorMsg : string option
  }

type Msg =
  | LoginSuccess of UserData
  | SetUserName of string
  | SetPassword of string
  | AuthError of exn
  | ClickLogIn
