//The nth term of the sequence of triangle numbers is given by, tn = ½n(n+1); so the first ten triangle numbers are:

//1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...

//By converting each letter in a word to a number corresponding to its alphabetical position and adding these values we form a word value. For example, the word value for SKY is 19 + 11 + 25 = 55 = t10. If the word value is a triangle number then we shall call the word a triangle word.

//Using words.txt (right click and 'Save Link/Target As...'), a 16K text file containing nearly two-thousand common English words, how many are triangle words?

open System.IO

let rec wordvalue (str: string) =
  60 + Array.sum(Array.map(fun c->(int c)-64)(str.ToCharArray()))

let rec wordvalue2 (str: string) =
  if (String.length str) > 0 then
    ((int str.[0]) - 64) + (wordvalue str.[1..])
  else
    0

let tri = seq{
  for n in [1..100] do
    yield ((n * (n+1)) / 2)}

let check str =
  let n = wordvalue2 str
  Seq.exists (fun i -> i = n) tri
    
printfn "%A" (Array.length (Array.filter check (File.ReadAllLines("042.txt").[0].Split [|','|])))