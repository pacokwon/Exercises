# Set 02

Only selected problems will have a solution.

### Problem 1

Write a function `prob1` that takes in a number `n` (int) and returns the n-th
[harmonic number](https://en.wikipedia.org/wiki/Harmonic_number) (float). For
any error case, this function should return `nan`.

```fsharp
val prob1: int -> float
```

##### Solution

```fsharp
let prob1 n =
  let rec aux ans n =
    if n = 1 then ans else aux (ans + 1.0 / float n) (n - 1)
  if n < 1 then nan else aux 1.0 n
```

### Problem 2

How many different ways can we make change of a given amount of money in Korean
coins? Suppose we have 5 different kinds of coins: 500-won coins, 100-won coins,
50-won coins, 10-won coins, and 1-won coins. Write a function `prob2` that takes
in an amount of money in won, and returns the number of possible
combinations. This function should return `-1` if an errorneous input is given,
e.g., when negative amount is given.

```fsharp
val prob2: int -> int
```

### Problem 3

Write a function `prob3` that computes GCD (Greatest Common Divisor) of two
given integers. This function should return `-1` for any error cases.

```fsharp
val prob3: int -> int -> int
```

### Problem 4

Write a function `prob4` that takes in an integer `n` and returns an integer
`1 + 2 + ... + (n-1) + n`. If n is a negative integer, this function should
return `-1`. This function should return `-1` for any error cases.

```fsharp
val prob4: int -> int
```

### Problem 5

Write a function `prob5` that takes in two integers `m` and `n`, and returns an
integer `m + (m+1) + (m+2) + ... + (m + (n-1)) + (m + n)`. This function should
return `-1` for any error cases. For instance, if `n` is negative, the function
should return `-1`.

```fsharp
val prob5: int -> int -> int
```

##### Solution

```fsharp
let prob5 m n =
  let rec aux ans n =
    if n < 0 then ans else aux (ans + m + n) (n - 1)
  if n < 0 then -1 else aux 0 n
```
