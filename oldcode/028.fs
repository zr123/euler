//Starting with the number 1 and moving to the right in a clockwise direction a 5 by 5 spiral is formed as follows:

//21 22 23 24 25
//20  7  8  9 10
//19  6  1  2 11
//18  5  4  3 12
//17 16 15 14 13

//It can be verified that the sum of the numbers on the diagonals is 101.

//What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed in the same way?

// f(d) = d + (d-1) + (d-2) + (d-3) .. + 3 + 2 + 1
let f d =
  if d < 2 then
    d
  else
    if (d % 2) = 0 then
      d + d/2 + (d/2 - 1) * d
    else
      d + (d-1) + (d-1)/2 + ((d-1)/2 - 1) * (d-1)

// solution(d) = answer where 5x5 -> d = (5-1)/2 = 2 ; 1001x1001 -> d = (1001-1)/2 = 500
let solution d =
  1 + 4*d + 20 * (f d) + 32 * (List.fold (fun sum num -> sum + (f (num-1))) 0 [1..d])

printfn "%A" (solution 500)

// sulution(d) = m(0) + m(1) + m(2) + ... m(d-2) + m(d-1) + m(d) ; where
// m(0) = 1
// m(1) = 20 * 1 + 4 + 32 * f(0)
// m(2) = 20 * 2 + 4 + 32 * f(1)
// m(d) = 20d + 4 + 32f(d-1)