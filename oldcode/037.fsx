//The number 3797 has an interesting property. Being prime itself, it is possible to continuously remove digits from left to right, and remain prime at each stage: 3797, 797, 97, and 7. Similarly we can work from right to left: 3797, 379, 37, and 3.

//Find the sum of the only eleven primes that are both truncatable from left to right and right to left.

//NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.

#load "Eulerlib.fs"

Eulerlib.calcPrimes 1000000

let rec testFromLeftToRight a =
  if Array.length a > 0 then
    Eulerlib.isPrime (Eulerlib.arrayToInt a) && (testFromLeftToRight a.[1 .. (Array.length a)-1])
  else
    true

let rec testFromRightToLeft a =
  if Array.length a > 0 then
    Eulerlib.isPrime (Eulerlib.arrayToInt a) && (testFromRightToLeft a.[0 .. (Array.length a)-2])
  else
    true

let test i =
  let a = Eulerlib.intToArray i
  testFromLeftToRight a && testFromRightToLeft a
    

let truncatablePrimes = 
  [for i in Eulerlib.primes do
    if test i then
      yield i]

printfn "%A" ((List.sum truncatablePrimes) - 2 - 3 - 5 - 7) //subtract exceptions