namespace Solutions

open Utils

module ClimbingStairs =
    let climbStairs (n:int) =

        // this is a fibonacci sequence - it's not that interesting, what IS cool however is the memoize function!
        let rec naive n =
            match n with
            | 0 -> 0
            | 1 -> 1
            | 2 -> 2
            | _ -> (naive (n-1) + naive (n-2))

        (memoize naive) n