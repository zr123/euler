//The sum of the squares of the first ten natural numbers is,
//1*1 + 2*2 + ... + 10*10 = 385
//The square of the sum of the first ten natural numbers is,
//(1 + 2 + ... + 10)**2 = 55**2 = 3025
//Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
//Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.

module Euler006

    let euler006 () =
        ((List.sum [0.0f..100.0f])**2.0f) - (List.sum (List.map (fun x -> x*x) [0.0f..100.0f]))
        
    printfn "%A" (euler006 ())