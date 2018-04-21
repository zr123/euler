//By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
//What is the 10001st prime number?

module Euler007
        
    let rec calcprimes (primes: int array) max = 
        let number = ref (primes.[primes.Length-1] + 2);
        while not (Array.forall (fun x -> !number % x <> 0) primes) do
            number := !number + 2
        if primes.Length < max then
            calcprimes (Array.append primes [|!number|]) max
        else 
              (Array.append primes [|!number|])
    
    let euler007 () =
        (calcprimes [|2;3|] 10001).[10000]

    printfn "%A" (euler007 ())