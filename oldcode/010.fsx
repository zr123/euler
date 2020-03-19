//The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
//
//Find the sum of all the primes below two million.

#load "Eulerlib.fs"
// ungefähr 2-3 mal so performant wie der alte code
Eulerlib.calcPrimes 2000000
printfn "%A" (Array.sum (Array.map int64 Eulerlib.primes))

//let rec calcprimes (primes: int array) max = 
//  let number = ref (primes.[primes.Length-1] + 2);
//  while not (Array.forall (fun x -> !number % x <> 0) primes) do
//    number := !number + 2
//  if !number < max then
//    calcprimes (Array.append primes [|!number|]) max
//  else 
//    primes

//printfn "%A" (Array.sum (Array.map int64 (calcprimes [|2;3|] 2000000)))