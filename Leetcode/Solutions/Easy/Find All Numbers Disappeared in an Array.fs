namespace Solutions

module FindAllNumbersDisappeared =
    let findAllNumbers (nums:int array): int array = 
        let expected = Set.ofList [1..nums.Length]
        let actualSet = Set.ofArray nums

        Set.toArray(expected - actualSet)