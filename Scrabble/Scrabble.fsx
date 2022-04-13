open System


type Tile = char
type Word = Tile list


let score (tile: Tile) : int =

    match (Char.ToUpper tile) with
    | c when List.contains c ['A';'E';'I';'O';'U';'L'; 'N'; 'R'; 'S'; 'T'] -> 1
    | c when List.contains c ['D';'G'] -> 2
    | c when List.contains c ['B'; 'C'; 'M'; 'P'] -> 3
    | c when List.contains c ['F'; 'H'; 'V'; 'W'; 'Y'] -> 4
    | 'K' -> 5
    | c when List.contains c ['J'; 'X'] ->8
    | c when List.contains c ['Q'; 'Z'] -> 10
    | _ -> 0


let scrabbleWord (str: string) = str |> Seq.toList

let calculateScore (word: Word) : int = word |> List.sumBy score


let cabbage:Word = scrabbleWord "cabbage"

printfn "%i" (calculateScore cabbage)