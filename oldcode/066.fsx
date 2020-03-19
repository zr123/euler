//Consider quadratic Diophantine equations of the form:

//x² – Dy² = 1

//For example, when D=13, the minimal solution in x is 649² – 13×180² = 1.

//It can be assumed that there are no solutions in positive integers when D is square.

//By finding minimal solutions in x for D = {2, 3, 5, 6, 7}, we obtain the following:

//3² – 2×2² = 1
//2² – 3×1² = 1
//9² – 5×4² = 1
//5² – 6×2² = 1
//8² – 7×3² = 1

//Hence, by considering minimal solutions in x for D ≤ 7, the largest x is obtained when D=5.

//Find the value of D ≤ 1000 in minimal solutions of x for which the largest value of x is obtained.



// see 066.jpg for math stuff
// weird behavoir: takes double but returns bigint D:
let findSolution d =
  let sqrt_d = (sqrt d)
  let isSquare n =
    if sqrt n = floor (sqrt d) then
      true
    else
      false
  
  // checks if the equation is true for the values of x and y
  let isValid (x, y) =
    x*x - (bigint (int64 d))*y*y = 1I
  
  // generates the actual fraction from a continued fraction list
  let getFraction l =
    if l <> [] then
      let mutable n = List.head l
      let mutable m = 1I
      for i in (List.tail l) do
        let tmp = n
        n <- m
        m <- tmp
        n <- n + i * m
      (n, m)
    else
      (0I, 0I)
  
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
  
let mutable max = 0I
let mutable max_d = 0.0
for d in [2.0 .. 1000.0] do
  let tmp = findSolution d
  if tmp > max then
    max <- tmp
    max_d <- d
    
printfn "%A" max_d