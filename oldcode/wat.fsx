#load "Eulerlib.fs"

let isSquare n =
  if sqrt n = floor (sqrt n) then
    true
  else
    false

// checks if the equation is true for the values of x and y
let isValid (x, y) d =
  x*x - (bigint (int64 d))*y*y = 1I

  // not happy with this!
let f = Eulerlib.continuedFraction (3.245) // -> [4; 12; 4; 3] = 3 + 49/200
printfn "%A" (f.getAandB ())
f.continueFraction ()
printfn "%A" (f.getAandB ())
f.continueFraction ()
printfn "%A" (f.getAandB ())
f.continueFraction ()
printfn "%A" (f.getAandB ())
f.continueFraction ()

printfn "%A" (f.getIntegerParts ()) // -> is wrong
(*
for i in [1.0 .. 1000.0] do
  if not (isSquare i) then
    let f = Eulerlib.continuedFraction (sqrt i)
    f.correctFractionSquare (i)
    while not (isValid (f.getFraction ()) i) do
      f.continueFraction ()
    printfn "%A-> %A" i (fst (f.getFraction ()))
*)  
(*
  
  // recursively generates the continued fraction for a value and checks if the equation holds true
  let rec continueFraction l a b =
    if not (isValid (getFraction l)) then
      let l_new = floor ((sqrt_d + a) / b)
      let a_new = l_new*b - a
      let b_new = (d - a_new*a_new) / b
      continueFraction ([bigint (int64 l_new)] @ l) a_new b_new
    else 
      fst (getFraction l)  
  
  if isSquare d then
    0I
  else
    continueFraction [] (0.0) 1.0
*)