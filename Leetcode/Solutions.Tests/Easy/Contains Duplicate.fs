module ContainsDuplicate

open Xunit
open Solutions

let testData: obj [] list =
    [ [| [ 1; 2; 3; 1 ]; false |]
      [| [ 1; 2; 3; 4 ]; false |]
      [| [ 1; 1; 1; 3; 3; 4; 3; 2; 4; 2 ]
         false |] ]


[<Theory>]
[<MemberData("testData")>]
let ``Contains Duplicate passes example leetcode test cases`` (input, expected) =
    Assert.Equal(ContainsDuplicate.containsDuplicate input, expected)
