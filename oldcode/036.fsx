// The decimal number, 585 = 10010010012 (binary), is palindromic in both bases.

// Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.

// (Please note that the palindromic number, in either base, may not include leading zeros.)

#load "Eulerlib.fs"

let isBinaryPalindrome n = 
  let mutable h = [||]
  for i in [0..30] do
    if pown 2 i <= n then
      if n &&& (pown 2 i) > 0 then
        h <- Array.append h [|'1'|]
      else
        h <- Array.append h [|'0'|]
  h = (Array.rev h)
  
let euler036 = 
  [for i in [1..999999] do
    if Eulerlib.isPalindrome i && isBinaryPalindrome i then
      yield i]
      
printfn "%A" (List.sum euler036)