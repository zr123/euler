//A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.

//Find the largest palindrome made from the product of two 3-digit numbers.

#load "Eulerlib.fs"

let l = [for i in [1..999] do for a in [i..999] do if Eulerlib.isPalindrome (i*a) then yield i*a]

printfn "%A" (List.max l)