//An irrational decimal fraction is created by concatenating the positive integers:

//0.123456789101112131415161718192021...

//It can be seen that the 12th digit of the fractional part is 1.

//If dn represents the nth digit of the fractional part, find the value of the following expression.

//d1 × d10 × d100 × d1000 × d10000 × d100000 × d1000000

let rec countdigits (i : int) =
  if i <> 0 then
    1 + (countdigits (i/10))
  else
    0

let mutable count = 0
let mutable threshold = 10
let mutable solution = 1
for i in [1..1000000] do
  count <- count + (countdigits i)
  if count >= threshold then
    solution <- solution * ((int (string i).[threshold - count + (countdigits i) - 1]) - 48)
    threshold <- threshold * 10

printfn "%d" solution