let isPrime (n: uint32) =
    let smallestDivisor (n: uint32) =
        let rec find_divisor (n: uint32) (cur: uint32) =
            if n % cur = 0u then int32 cur
            else find_divisor n (cur + 1u)

        if n = 1u then -1
        else find_divisor n 2u

    uint32 (smallestDivisor n) = uint32 n
