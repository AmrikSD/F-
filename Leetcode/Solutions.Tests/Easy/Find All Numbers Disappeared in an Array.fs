module FindAllNumbersDisappeared

open System.Collections
open Solutions
open Xunit

type TestCases() =
    let values: seq<obj []> =
        seq {
            yield [| [| 4;3;2;7;8;2;3;1 |]; [| 5;6 |] |]
            yield [| [| 1;1 |]; [| 2 |] |]
        }

    interface seq<obj []> with
        member this.GetEnumerator() = values.GetEnumerator()

        member this.GetEnumerator() =
            values.GetEnumerator() :> System.Collections.IEnumerator

module Theories =
    [<Theory>]
    [<ClassData(typeof<TestCases>)>]
    let ``given an array it should be able to pass it to the test`` (input: int array, expected: int array) =
        Assert.Equal<int array>(expected, FindAllNumbersDisappeared.findAllNumbers input) 