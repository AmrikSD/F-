open System

type Multiplier =
    | Double
    | Triple

type Tile =
    { Letter: char
      Multiplier: Multiplier option }

type Word =
    { Letters: Tile list
      Multiplier: Multiplier option }

let multiplierToInt (mopt: Multiplier Option) : int =
    match mopt with
    | None -> 1
    | Some Double -> 2
    | Some Triple -> 3

let score (tile: Tile) : int =

    (match (Char.ToUpper tile.Letter) with
     | c when
         List.contains
             c
             [ 'A'
               'E'
               'I'
               'O'
               'U'
               'L'
               'N'
               'R'
               'S'
               'T' ]
         ->
         1
     | c when List.contains c [ 'D'; 'G' ] -> 2
     | c when List.contains c [ 'B'; 'C'; 'M'; 'P' ] -> 3
     | c when List.contains c [ 'F'; 'H'; 'V'; 'W'; 'Y' ] -> 4
     | 'K' -> 5
     | c when List.contains c [ 'J'; 'X' ] -> 8
     | c when List.contains c [ 'Q'; 'Z' ] -> 10
     | _ -> 0)
    * (multiplierToInt tile.Multiplier)

let calculateScore (word: Word) : int =
    word.Letters
    |> List.sumBy score
    |> (*) (multiplierToInt word.Multiplier)


let cabbage: Word =
    { Letters =
        [ { Letter = 'C'; Multiplier = None }
          { Letter = 'a'; Multiplier = None }
          { Letter = 'b'; Multiplier = None }
          { Letter = 'b'; Multiplier = None }
          { Letter = 'a'; Multiplier = None }
          { Letter = 'g'; Multiplier = None }
          { Letter = 'e'; Multiplier = None } ]
      Multiplier = Some Double }

printfn "%i" (calculateScore cabbage)
