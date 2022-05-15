module BestTimeToBuy


open Solutions
open Xunit

// https://stackoverflow.com/questions/35026735/in-f-how-do-you-pass-a-collection-to-xunits-inlinedata-attribute
// Shoutout to @bytebuster...

type TestCases() =
    let values: seq<obj []> =
        seq {
            yield [| [| 7;1;5;3;6;4 |]; 5 |]
            yield [| [| 7;6;4;3;1 |]; 0 |]
        }

    interface seq<obj []> with
        member this.GetEnumerator() = values.GetEnumerator()

        member this.GetEnumerator() =
            values.GetEnumerator() :> System.Collections.IEnumerator

module Theories =
    [<Theory>]
    [<ClassData(typeof<TestCases>)>]
    let ``given an array it should be able to pass it to the test`` (input: int array, expected: int) : unit =
        Assert.Equal(expected, BestTimeToBuy.maxProfit input)
