//The first two consecutive numbers to have two distinct prime factors are:

//14 = 2 × 7
//15 = 3 × 5

//The first three consecutive numbers to have three distinct prime factors are:

//644 = 2² × 7 × 23
//645 = 3 × 5 × 43
//646 = 2 × 17 × 19.

//Find the first four consecutive integers to have four distinct prime factors. What is the first of these numbers?

let rec uniqueprimesfactors num div = 
  // teilt n durch n bis es nicht mehr möglich ist
  let rec helper n d =
    if (n % d = 0) && (n <> 1) then
      helper (n/d) d
    else
      n
  if num <> 1 then
    if num % div = 0 then
      List.append [div] (uniqueprimesfactors (helper num div) div)
    else
      (uniqueprimesfactors num (div+1))
  else
    []
    
let countunique l k =
  Seq.length (Seq.countBy (fun x -> x) (List.append l k))

let check l k =
  if ((List.length l) >= 4) && ((List.length l) + (List.length k) - (countunique l k) = 0) then
    true
  else
    false

let mutable l1 = uniqueprimesfactors 10 2
let mutable l2 = uniqueprimesfactors 11 2
let mutable l3 = uniqueprimesfactors 12 2
let mutable l4 = uniqueprimesfactors 13 2
for i in [14 .. 1000000] do
  if (check (uniqueprimesfactors i 2) l4) && (check l4 l3) && (check l3 l2) && (check l2 l1) then
    printfn "%d" (i - 3)
  l1 <- l2
  l2 <- l3
  l3 <- l4
  l4 <- uniqueprimesfactors i 2
