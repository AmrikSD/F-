module SingleNumber


open Solutions
open Xunit

// https://stackoverflow.com/questions/35026735/in-f-how-do-you-pass-a-collection-to-xunits-inlinedata-attribute
// Shoutout to @bytebuster...

type TestCases() =
    let values: seq<obj []> =
        seq {
            yield [| [| 2;2;1 |]; 1 |]
            yield [| [| 4;1;2;1;2 |]; 4 |]
            yield [| [| 1 |]; 1 |]
        }

    interface seq<obj []> with
        member this.GetEnumerator() = values.GetEnumerator()

        member this.GetEnumerator() =
            values.GetEnumerator() :> System.Collections.IEnumerator

module Theories =
    [<Theory>]
    [<ClassData(typeof<TestCases>)>]
    let ``given an array it should be able to pass it to the test`` (input: int array, expected: int) : unit =
        Assert.Equal(expected, SingleNumber.singleNumber input)
