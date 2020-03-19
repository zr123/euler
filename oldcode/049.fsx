//The arithmetic sequence, 1487, 4817, 8147, in which each of the terms increases by 3330, is unusual in two ways: (i) each of the three terms are prime, and, (ii) each of the 4-digit numbers are permutations of one another.

//There are no arithmetic sequences made up of three 1-, 2-, or 3-digit primes, exhibiting this property, but there is one other 4-digit increasing sequence.

//What 12-digit number do you form by concatenating the three terms in this sequence?

#load "Eulerlib.fs"

Eulerlib.calcPrimes 10000

let isPermutation a b =
  (List.sort (Eulerlib.intToList a)) = (List.sort (Eulerlib.intToList b))

for i in Eulerlib.primes do
  if i > 1000 then
    for c in [1..3333] do
      if Eulerlib.isPrime (i + c) && Eulerlib.isPrime (i + 2*c) then
        if isPermutation i (i + c) && isPermutation (i + c) (i + 2*c) then
          if i <> 1487 then // vorgegebene Antwort verwerfen
            printfn "%A%A%A" i (i + c) (i + 2*c)