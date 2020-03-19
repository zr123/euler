//It was proposed by Christian Goldbach that every odd composite number can be written as the sum of a prime and twice a square.

//9 = 7 + 2×12
//15 = 7 + 2×22
//21 = 3 + 2×32
//25 = 7 + 2×32
//27 = 19 + 2×22
//33 = 31 + 2×12

//It turns out that the conjecture was false.

//What is the smallest odd composite that cannot be written as the sum of a prime and twice a square?

#load "Eulerlib.fs"

let test x =
  let mutable i = 0
  while (x - 2*i*i) > 0 && not (Eulerlib.isPrime (x - 2*i*i)) do
    i <- i+1
  if (x - 2*i*i) < 0 then
    true
  else 
    false
      
let mutable i = 5
while not (test i) do
  i <- i + 2

printfn "%A" i