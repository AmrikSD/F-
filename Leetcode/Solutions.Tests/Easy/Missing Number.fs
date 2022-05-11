module MissingNumber


open Solutions
open Xunit

// https://stackoverflow.com/questions/35026735/in-f-how-do-you-pass-a-collection-to-xunits-inlinedata-attribute
// Shoutout to @bytebuster...

type TestCases() =
    let values: seq<obj []> =
        seq {
            yield [| [| 3; 0; 1 |]; 2 |]
            yield [| [| 0; 1 |]; 2 |]
            yield [| [| 9; 6; 4; 2; 3; 5; 7; 0; 1 |]; 8 |]
        }

    interface seq<obj []> with
        member this.GetEnumerator() = values.GetEnumerator()

        member this.GetEnumerator() =
            values.GetEnumerator() :> System.Collections.IEnumerator

module Theories =
    [<Theory>]
    [<ClassData(typeof<TestCases>)>]
    let ``given an array it should be able to pass it to the test`` (input: int array, expected: int) : unit =
        Assert.Equal(MissingNumber.missingNumber input, expected)
