module ClimbingStairs


open Solutions
open Xunit

// https://stackoverflow.com/questions/35026735/in-f-how-do-you-pass-a-collection-to-xunits-inlinedata-attribute
// Shoutout to @bytebuster...

type TestCases() =
    let values: seq<obj []> =
        seq {
            yield [| 2; 2 |]
            yield [| 3; 3 |]
            yield [| 4; 5|]
            yield [| 5; 8|]
        }

    interface seq<obj []> with
        member this.GetEnumerator() = values.GetEnumerator()

        member this.GetEnumerator() =
            values.GetEnumerator() :> System.Collections.IEnumerator

module Theories =
    [<Theory>]
    [<ClassData(typeof<TestCases>)>]
    let ``given an array it should be able to pass it to the test`` (input: int, expected: int) =
        Assert.Equal(expected, ClimbingStairs.climbStairs input)
