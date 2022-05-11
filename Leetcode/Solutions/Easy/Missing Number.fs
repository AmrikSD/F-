namespace Solutions

module MissingNumber =
    let missingNumber (nums: int array) =
        let n = nums.Length
        let expectedSum = n * (n - 1) / 2 //sum to n formula...
        let sum = Array.sum nums

        expectedSum + n - sum
