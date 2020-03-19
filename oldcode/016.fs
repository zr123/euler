
open System.Numerics

let mutable num = BigInteger.Pow(2I,1000)
let mutable sum = 0I

while num > 0I do
  sum <- sum + num%10I
  num <- num / 10I

printfn "%A" sum 

let rec digit_sum x =
  if x <> 0I then
    (x%10I) + (digit_sum (x/10I))
  else
    0I

printfn "%A" (digit_sum(BigInteger.Pow(2I,1000)))