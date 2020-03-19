(*
let Pentagonal = Seq.unfold (fun n -> Some ( n * ( 3 * n - 1 ) / 2 , n+1 )) 0
let isPentagonal n =
  (((sqrt (24.0 * n + 1.0)) + 1.0) / 6.0) % 1.0 = 0.0

let loop = ref true
let mutable c = 1


while !loop do
  for i in c-1 .. -1 .. 1 do
    if (isPentagonal (float ((Seq.nth i Pentagonal) + (Seq.nth c Pentagonal)))) then
      printfn "level 1: %A" (Seq.nth c Pentagonal)
      if (isPentagonal (float ((Seq.nth i Pentagonal) - (Seq.nth c Pentagonal)))) then
        loop := false
        printfn "success: %A %A" i c
  c <- c+1
*)

//check if the sum of the nth and nth pentagonal number is also pentagonal
//beware: math (if n or m exceeds ~32000 (sqrt 10^9) integers will overflow --- nevermind, we have floats anyway)
let check1 n m =
  let a = ((sqrt (36.0*n**2.0 - 12.0*n + 36.0*m**2.0 - 12.0*m + 1.0)) + 1.0) / 6.0
  ((floor a) = a)

// m musst be the smaller number
let check2 n m =
  let a = ((sqrt (36.0*n**2.0 - 12.0*n - 36.0*m**2.0 + 12.0*m + 1.0)) + 1.0) / 6.0
  ((floor a) = a)  

//for i in 5.0 .. 32000.0 do
//  for c in i-1.0 .. -1.0 .. 1.0 do
//    if (check1 i c) && (check2 i c) then
//      printfn "check: (%A,%A)" i c

let calcdiff (a,b) =
  (a * ( 3.0 * a - 1.0 ) / 2.0) - (b * ( 3.0 * b - 1.0 ) / 2.0)
  
let rec euler044 f =
  let mutable r = (0.0,0.0)
  for c in f-1.0 .. -1.0 .. 1.0 do
    if (check1 f c) && (check2 f c) then
      r <- (f,c)
  if r <> (0.0,0.0) then
    (int (calcdiff r))
  else
    euler044 (f+1.0)

printfn "%A" (euler044 1.0)