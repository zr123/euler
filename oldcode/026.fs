//A unit fraction contains 1 in the numerator. The decimal representation of the unit fractions with denominators 2 to 10 are given:
//
//    1/2	= 	0.5
//    1/3	= 	0.(3)
//    1/4	= 	0.25
//    1/5	= 	0.2
//    1/6	= 	0.1(6)
//    1/7	= 	0.(142857)
//    1/8	= 	0.125
//    1/9	= 	0.(1)
//    1/10	= 	0.1
//
//Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. It can be seen that 1/7 has a 6-digit recurring cycle.
//
//Find the value of d < 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.

//find dimension of a number, ie. 7 -> 10; 11 -> 100; 100 -> 1000 and so on
//obsolete
let rec getdim i =
  if (i / 10) = 0 then
    10
  else
    10 * (getdim (i / 10))

// returns the size of the repeating cycle of 1/d, run with offset = 10 and stuff = List.empty<int>
// doesn't really count the longest repeating cycle, only counts where the first cycle apears
// ie d = 6 -> 0.1(6) returns 2 instead of 1 because the cycle starts at the 2nd digit, but the first digit isn't part of the cycle
let rec findcycle (offset : int) (d: int) (stuff: int list) = 
  let remainder = (offset % d) * 10
  if (remainder = 0) || (List.exists (fun elem -> elem = remainder) stuff) then
    0
  else
    1 + (findcycle remainder d (List.append stuff [remainder]))

// find largest cycle for 2..999
let mutable maximum = 0
let mutable num = 0
for i in [2 .. 999] do
  let cycle = findcycle 10 i List.empty<int>
  if cycle > maximum then
    maximum <- cycle
    num <- i

printfn "%d" num