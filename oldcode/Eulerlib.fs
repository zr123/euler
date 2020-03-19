module Eulerlib

//### Primestuff
let mutable primes = [|2;3;5|]
let mutable maxPrime = 5

let rec isPrime n =
  // Wenn bereits bekannt, einfach aus Liste zurückgeben
  if n < 2 then
    false
  else
    if n <= maxPrime then
      if (Array.tryFind (fun x -> n = x) primes) = None then
        false
      else
        true
    else
    // andernfalls berechnen
      let mutable squareRoot = (int (sqrt (double n)))
      if squareRoot > maxPrime then
        calcPrimes squareRoot
        squareRoot <- maxPrime // auf maxPrime setzen damit nicht versehentlich der prime-array überlaufen wird
      let mutable i = 0
      while (n % primes.[i]) <> 0 && primes.[i] < squareRoot do
        i <- i+1
      if (n % primes.[i]) = 0 then
        false
      else
        true
    
// primzahle bis <= n berechnen
and calcPrimes n =
  for i in [(maxPrime+2) .. 2 .. n] do
    if isPrime i then
      primes <- Array.append primes [|i|]
      maxPrime <- i

// n'te Primzahl berechnen
let calcNthPrime n =
  let mutable i = maxPrime + 2
  while Array.length primes <= n do
    if isPrime i then
      primes <- Array.append primes [|i|]
      maxPrime <- i
    i <- i + 1

//### Fraction class
// see 066.jpg for math behind this. Only really works for square roots
type continuedFraction (decimalFraction: double) =
  let mutable integerParts = []
  let mutable fractionSquare = decimalFraction*decimalFraction
  let mutable a = 0.0
  let mutable b = 1.0
  // calling this is neccessary if decimalFraction is a square root
  member this.correctFractionSquare (d) =
    fractionSquare <- d
  member this.continueFraction () =
    let integerPartEntry = floor ((decimalFraction + a) / b)
    a <- integerPartEntry*b - a
    b <- (fractionSquare - a*a) / b
    integerParts <- [bigint (int64 integerPartEntry)] @ integerParts
  member this.getFraction () =
    if integerParts <> [] then
      let mutable n = List.head integerParts
      let mutable m = 1I
      for i in (List.tail integerParts) do
        let tmp = n
        n <- m
        m <- tmp
        n <- n + i * m
      (n, m)
    else
      (0I, 0I)
  member this.getIntegerParts () =
    integerParts
  member this.getAandB () =
    (a, b)
    
//### Digitstuff
//turn an integer into an list of its digits
let rec intToList i =
  if i > 0 then
    List.append [i%10] (intToList (i/10))
  else
    []

//turn a list of digits back into an integer
let rec listToInt l =
  if (List.length l) > 0 then
    List.head l + 10* (listToInt (List.tail l))
  else
    0

//turn a list of digits into a bigint
let rec listToBigInt (l : int list) =
  if (List.length l) > 0 then
    bigint (List.head l) + 10I*(listToBigInt (List.tail l))
  else
    0I

let rec intToArray i =
  if i > 0 then
    Array.append [|i%10|] (intToArray (i/10))
  else
    [||]

let rec bigIntToArray i =
  if i > 0I then
    Array.append [|int (i%10I)|] (bigIntToArray (i/10I))
  else
    [||]

let rec arrayToInt a =
  if Array.length a > 0 then
    a.[0]  + 10* (arrayToInt a.[1 .. (Array.length a)-1])
  else
    0

let rec arrayToBigInt (a : int array) =
  if Array.length a > 0 then
    (bigint a.[0])  + 10I* (arrayToBigInt a.[1 .. (Array.length a)-1])
  else
    0I

let isPalindrome n = 
  let h = (string n).ToCharArray()
  h = (Array.rev h)

let rec factorial n =
  if n > 1I then
    n * (factorial (n - 1I))
  else
    1I