module Conference.Api.Persons

open API
open Infrastructure.Types
open Domain.Events
open Domain.Model

type PersonsReadModel =
  Person list

let heimeshoff = person "Marco" "Heimeshoff" "311b9fbd-98a2-401e-b9e9-bab15897dad4"
let fellien = person "Janek" "Felien" "489cc178-9698-458e-9c4e-95488e159f6d"
let poepke = person "Conrad" "Poepke" "6740b188-e5ec-425d-8e97-c8bc6fb0c35a"

let sachse = person "Roman" "Sachse" "f193649a-0901-4c43-9168-37ef306d3262"

let organizers =
  [
    heimeshoff
    fellien
    poepke
    sachse
  ]

let projection : ProjectionDefinition<PersonsReadModel, Event>=
  {
    InitialState = organizers
    UpdateState = fun readmodel _ -> readmodel
  }

let queryHandler (query : Query<QueryParameter>) (readModel : PersonsReadModel) : QueryHandled<QueryResult> =
  match query.Parameter with
  | QueryParameter.Persons ->
      readModel
      |> QueryResult.Persons
      |> Handled

  | _ -> NotHandled