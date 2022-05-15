namespace Solutions

open System.Collections.Generic

module Utils =
    // Dumb function that just returns what you put in, for easy tests..
    let echo s = s

    // This function takes any other function and memoizes it such that it can be used in a DP problem, VERY cool!
    let memoize f = 
        let cache = new Dictionary<_,_>()

        fun x -> (
            let cacheHit, v = cache.TryGetValue(x)
            if cacheHit then
                v
            else
                let v = f x
                cache.Add(x,v)
                v
        )