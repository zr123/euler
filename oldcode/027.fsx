//Euler discovered the remarkable quadratic formula:

//n² + n + 41

//It turns out that the formula will produce 40 primes for the consecutive values n = 0 to 39. However, when n = 40, 402 + 40 + 41 = 40(40 + 1) + 41 is divisible by 41, and certainly when n = 41, 41² + 41 + 41 is clearly divisible by 41.

//The incredible formula  n² − 79n + 1601 was discovered, which produces 80 primes for the consecutive values n = 0 to 79. The product of the coefficients, −79 and 1601, is −126479.

//Considering quadratics of the form:

//n² + an + b, where |a| < 1000 and |b| < 1000


//where |n| is the modulus/absolute value of n
//e.g. |11| = 11 and |−4| = 4

//Find the product of the coefficients, a and b, for the quadratic expression that produces the maximum number of primes for consecutive values of n, starting with n = 0.

#load "Eulerlib.fs"

let formula n a b = n*n + n*a + b

let mylist = [
  for i in -999..999 do
    for c in 0..999  //b > 0 because formula produces negative numbers for n=0 (there are no negative primes)
      -> (i,c)]

//let mylist = Seq.toList (seq{
//  for i in [-999..999] do
//    for c in [0..999] do //b > 0 because formula produces negative numbers for n=0 (there are no negative primes)
//      yield (i,c)})

let rec find n l =
  if (List.length l) = 1 then
    l
  else
    find (n+1) (List.filter (fun (a,b) -> Eulerlib.isprime (formula n a b)) l)

printfn "%A" (match (find 0 mylist).[0] with (a,b) -> a * b)