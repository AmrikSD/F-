// This example is from: https://zaid-ajaj.github.io/Npgsql.FSharp/#/usecases/parameters

// This is how to install nuget packages in the "script" files of F#
#r "nuget: Npgsql.FSharp"
open Npgsql.FSharp


// Getting a connection string
let connectionString: string =
    Sql.host "localhost"
    |> Sql.database "postgres"
    |> Sql.username "postgres"
    |> Sql.password "example"
    |> Sql.port 5432
    |> Sql.formatConnectionString

// Define our data type
// Note that we don't need active in here
type User =
    { Id: int
      Username: string
      Email: string
      }


let readUser = Sql.execute (fun read ->
        { Id = read.int "user_id"
          Username = read.text "username"
          Email = read.text "email" }) 


let printUser user = printfn "User (%d) -> {%s}" user.Id user.Email


// Create a function that will query the database
// readUsers will read _all_ users from the "users" table
let readUsers (connectionString) : User list =
    connectionString
    |> Sql.connect
    |> Sql.query "SELECT * FROM users"
    |> readUser

let activeUsers (connectionString) : User list =
    connectionString
    |> Sql.connect
    |> Sql.query "SELECT * FROM users WHERE active = @active"
    |> Sql.parameters ["@active", Sql.bool true]
    |> readUser






// Execute the functionS we just made, store the result in a variable

printfn "all the users"
let users = readUsers connectionString

users
|> List.iter printUser

printfn "only the active ones"
let active = activeUsers connectionString

active
|> List.iter printUser