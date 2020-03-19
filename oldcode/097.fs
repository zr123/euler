//The first known prime found to exceed one million digits was discovered in 1999, and is a Mersenne prime of the form 26972593−1; it contains exactly 2,098,960 digits. Subsequently other Mersenne primes, of the form 2p−1, have been found which contain more digits.

//However, in 2004 there was found a massive non-Mersenne prime which contains 2,357,207 digits: 28433×27830457+1.

//Find the last ten digits of this prime number.

open System.Numerics

let rec powh i n =
  if n <> 1L then
    powh ((i*2L) % 10000000000L) (n-1L)
  else
    i
  
//printfn "%A" ((28433I * (pown 2I 7830457) + 1I) % 1000000000)  // discarted because lack of speed
printfn "%A" ((28433L * (powh 2L 7830457L) + 1L) % 10000000000L)