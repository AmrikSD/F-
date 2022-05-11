namespace Solutions

module ContainsDuplicate =
    let containsDuplicate (nums:int array) =
        Set.ofArray(nums).Count < nums.Length
