namespace Solutions

module SingleNumber =
    let singleNumber (nums:int array): int =
        (0, nums) ||> Array.fold (fun acc num -> acc ^^^ num)
        // this is not very readable..
        // what it's doing is an XOR on each element in the array. 
        // We know N XOR N = 0, 
        // 0 XOR N = N, 
        // therefore if all elements are present exactly 2 times except one, called q, the result will be q...