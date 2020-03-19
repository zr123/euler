//It is possible to show that the square root of two can be expressed as an infinite continued fraction.

//√ 2 = 1 + 1/(2 + 1/(2 + 1/(2 + ... ))) = 1.414213...

//By expanding this for the first four iterations, we get:

//1 + 1/2 = 3/2 = 1.5
//1 + 1/(2 + 1/2) = 7/5 = 1.4
//1 + 1/(2 + 1/(2 + 1/2)) = 17/12 = 1.41666...
//1 + 1/(2 + 1/(2 + 1/(2 + 1/2))) = 41/29 = 1.41379...

//The next three expansions are 99/70, 239/169, and 577/408, but the eighth expansion, 1393/985, is the first example where the number of digits in the numerator exceeds the number of digits in the denominator.

//In the first one-thousand expansions, how many fractions contain a numerator with more digits than denominator?

let getNextIteration (a, b) =
  (2I*b + a, a + b)
    
let checkMagnitues (a, b) =
  let mutable (n, m) = (a, b)
  while m > 0I do
    n <- n/10I
    m <- m/10I
  if n > 0I then
    true
  else
    false
  
let mutable (a, b, count) = (1I, 1I, 0)
for i in [1I..1000I] do
  let (tmp1, tmp2) = (getNextIteration (a, b))
  a <- tmp1
  b <- tmp2
  if checkMagnitues (a, b) then
    count <- count + 1
    
printfn "%A" count