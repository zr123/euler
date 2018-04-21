//The prime factors of 13195 are 5, 7, 13 and 29.
//What is the largest prime factor of the number 600851475143 ?

module Euler003

    let rec getPrimeFactors n =
        let prime = Seq.find (fun x -> n % x = 0L) (seq {2L .. n})
        let newN = n / prime
        if (newN <> 1L) then
            List.append [prime] (getPrimeFactors newN)
        else
            [prime]

    let euler003 () =
        List.max (getPrimeFactors 600851475143L)

