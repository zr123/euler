let rec fac x = 
  if x <> 1I then
    x * (fac (x-1I))
  else
   1I

let mutable i = (fac 100I)
let mutable sum = 0I

while i <> 0I do
  sum <- sum + i%10I
  i <- i/10I

printfn "%A" sum

let rec digitsum x =
  if x = 0I then
    0I
  else
    (x%10I) + (digitsum (x/10I))

printfn "%A" (digitsum (List.fold (*) 1I [1I..100I]))
// EINZEILER MACHEN! :D