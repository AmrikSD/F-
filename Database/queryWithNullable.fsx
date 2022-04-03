// This example is from: https://zaid-ajaj.github.io/Npgsql.FSharp/#/usecases/dealing-with-null

// This is similar to ./queryExample - but with optional nulls, so this time the table looks like - run `diff queryWithNullableExample.fsx queryExample.fsx`

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
type User =
    { Id: int
      Username: string
      Email: string
      FirstName: Option<string>
      LastName: Option<string> }


// Create a function that will query the database
// readUsers will read _all_ users from the "users" table
let readUsers (connectionString) : User list =
    connectionString
    |> Sql.connect
    |> Sql.query "SELECT * FROM users"
    |> Sql.execute (fun read ->
        { Id = read.int "user_id"
          Username = read.text "username"
          Email = read.text "email"
          FirstName = read.textOrNone "first_name"
          LastName = read.textOrNone "last_name" })

// Now we need a helper to deal with the optional fields
let parseOpt str =
    match str with
    | Some s -> s
    | None -> "null"

// Execute the function we just made, store the result in a variable
let users = readUsers connectionString

users
|> List.iter (fun user ->
    printfn
        "User (%d) -> {%s} - {%s} - {%s} - {%s}"
        user.Id
        user.Email
        user.Username
        (parseOpt user.FirstName) // Because we need a string in the printfn %s field, we can use parseOpt to force it to say "null"
        (parseOpt user.LastName))
