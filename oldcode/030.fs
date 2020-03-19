//Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:

//    1634 = 1^4 + 6^4 + 3^4 + 4^4
//    8208 = 8^4 + 2^4 + 0^4 + 8^4
//    9474 = 9^4 + 4^4 + 7^4 + 4^4

//As 1 = 14 is not a sum it is not included.

//The sum of these numbers is 1634 + 8208 + 9474 = 19316.

//Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.

let pow5 x = x*x*x*x*x

let f x = pow5(x%10) + pow5((x/10)%10) + pow5((x/100)%10) + pow5((x/1000)%10) + pow5((x/10000)%10) + pow5((x/100000)%10)

printfn "%A" (List.sum (List.filter (fun x -> x = (f x)) [2..(6*(pow5 9))]))