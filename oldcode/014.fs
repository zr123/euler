let rec collatz x =
  if x <> 1L then
    if (x % 2L) = 0L then
      1L + (collatz (x/2L))
    else
      1L + (collatz (x*3L+1L))
  else
    1L


let mutable max = 1L
let mutable num = 1L
for i in [999999L .. -1L .. 1L] do
  if (collatz i) > max then
    max <- collatz i
    num <- i


printfn "collatz %A = %A" num max