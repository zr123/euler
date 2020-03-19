//Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
//If d(a) = b and d(b) = a, where a ? b, then a and b are an amicable pair and each of a and b are called amicable numbers.

//For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.

//Evaluate the sum of all the amicable numbers under 10000.

let divsum x = 
  let mutable sum = 1
  for i in [2 .. int32(sqrt(double(x)))] do
    if x%i = 0 then
      sum <- sum + i + (x/i)
  sum
  
let numbers = Array.init 10000 divsum
//let numbers = [| for i in [0..9999] -> (divsum i) |]
//let numbers = [| for i in [0..9999] do yield (divsum i) |]
//geht auch

let mutable total = 0
for i in [2..9999] do
  if (numbers.[i] < 10000) && (i = numbers.[numbers.[i]]) then
    if i <> numbers.[i] then
      total <- total + i

printfn "%d" total

//let testseq = Seq.initInfinite divsum
//printfn "%d" (Seq.nth 220 testseq)