module ContainsDuplicate

open Xunit
open Solutions

// https://stackoverflow.com/questions/35026735/in-f-how-do-you-pass-a-collection-to-xunits-inlinedata-attribute
// Shoutout to @bytebuster...

type TestCases () =    
    let values : seq<obj[]>  =
        seq {
            yield [|[| 1;2;3;1 |]; true |]
            yield [|[| 1;2;3;4 |]; false |]  
        }
    interface seq<obj[]> with
        member this.GetEnumerator () = values.GetEnumerator()
        member this.GetEnumerator () =
            values.GetEnumerator() :> System.Collections.IEnumerator

module Theories = 
    [<Theory>]
    [<ClassData(typeof<TestCases>)>]
    let ``given an array it should be able to pass it to the test`` (input : int array, expected : bool) : unit = 
        Assert.Equal(ContainsDuplicate.containsDuplicate input, expected)
