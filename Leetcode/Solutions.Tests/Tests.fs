module Tests

open Xunit
open Solutions

[<Fact>]
let ``My test`` () = Assert.True(true)



[<Theory>]
[<InlineData(1, 1)>]
[<InlineData("hi", "hi")>]
[<InlineData(-23, -23)>]
[<InlineData(11, 11)>]
[<InlineData(15, 15)>]
[<InlineData(false, false)>]
[<InlineData(true, true)>]
[<InlineData("a long string", "a long string")>]
let ``Echo returns the same object`` (a, b) =
    Assert.Equal(Utils.echo a, Utils.echo a)
