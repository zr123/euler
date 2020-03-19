//A googol (10100) is a massive number: one followed by one-hundred zeros; 100100 is almost unimaginably large: one followed by two-hundred zeros. Despite their size, the sum of the digits in each number is only 1.

//Considering natural numbers of the form, ab, where a, b < 100, what is the maximum digital sum?

#load "Eulerlib.fs"

let calcSum a b =
  Array.sum (Eulerlib.bigIntToArray (a ** b))

let sums = [for i in [1I..99I] do for c in [1..99] do yield calcSum i c]
printfn "%A" (List.max sums)