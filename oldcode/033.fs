// The fraction 49/98 is a curious fraction, as an inexperienced mathematician in attempting to simplify it may incorrectly believe that 49/98 = 4/8, which is correct, is obtained by cancelling the 9s.
//
// We shall consider fractions like, 30/50 = 3/5, to be trivial examples.
//
// There are exactly four non-trivial examples of this type of fraction, less than one in value, and containing two digits in the numerator and denominator.
//
// If the product of these four fractions is given in its lowest common terms, find the value of the denominator.

// ie 49 / 98
let check a aa b bb =
  let a1 = double a
  let a2 = double aa
  let b1 = double b
  let b2 = double bb
  if a = 0 || aa = 0 || b = 0 || bb = 0 then
    false
  else
    if (a1*10.0 + a2) / (b1*10.0 + b2) = a1/b2 && a2 = b1 then
      true
    else
      false

let solutions = seq{
  for i in [10..98] do
    for c in [i+1..99] do
      if check (i/10) (i%10) (c/10) (c%10) then
        yield ((double i),(double c))}

printfn "%A" (Seq.fold (fun acc (x,y) -> acc*y/x) 1.0 solutions)