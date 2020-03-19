//A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.

//A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.

//As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24. By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers. However, this upper limit cannot be reduced any further by analysis even though it is known that the greatest number that cannot be expressed as the sum of two abundant numbers is less than this limit.

//Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.

let divsum x = 
  (List.fold (fun count l -> if l <> x/l then count + l + (x/l) else count + l) 1 (List.filter (fun z -> (x%z) = 0) [2 .. int(sqrt(double(x)))]))

let abundands = [for i in [10..28123] do if i < (divsum i) then yield i]
let abundandsums = seq {
  for i in abundands do
    for z in abundands do
      yield (i+z)}

printfn "%d" ((List.sum [1..28123]) -  (Seq.sum (Seq.filter (fun x -> x <= 28123) (Seq.sort (Seq.distinct abundandsums)))))