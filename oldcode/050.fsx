//The prime 41, can be written as the sum of six consecutive primes:
//41 = 2 + 3 + 5 + 7 + 11 + 13

//This is the longest sum of consecutive primes that adds to a prime below one-hundred.

//The longest sum of consecutive primes below one-thousand that adds to a prime, contains 21 terms, and is equal to 953.

//Which prime, below one-million, can be written as the sum of the most consecutive primes?

#load "Eulerlib.fs"

Eulerlib.calcPrimes 100000
let mutable consecutivePrimes = []

let rec herpderp l =  
  let mutable sum = 0
  let mutable index = 0
  if List.length l > 0 then 
    for i in l do
      sum <- sum + i
      index <- index + 1
      if Eulerlib.isPrime sum && sum < 1000000 && index > 0 then
        consecutivePrimes <- consecutivePrimes @ [(sum, index)]
    herpderp (List.tail l)

herpderp (List.ofArray Eulerlib.primes)

let findMax l =
  let mutable m = 0
  let mutable p = 0
  for (a,b) in l do
    if b > m then
      m <- b
      p <- a
  p 
 
printfn "%A" (findMax consecutivePrimes)