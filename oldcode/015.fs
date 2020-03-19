let rec dim a b =
  if (a = 0I) || (b = 0I) then
    1I
  else
    (dim (a-1I) b) + (dim a (b-1I))

// ULTRA unperformante rekursive funktion, nicht verwenden braucht stunden, wenn nicht tage oder schlimmer

let matrix_dimension = 20
let matrix = Array2D.create matrix_dimension matrix_dimension 0I
for n in 1 .. matrix_dimension do
  matrix.[0,n-1] <- bigint(n)+1I
for n in 2 .. matrix_dimension do
  for i in 1 .. matrix_dimension do
    if i < n then
      matrix.[n-1,i-1] <- 0I
    else
      if i = n then
        matrix.[n-1,i-1] <- 2I*matrix.[n-2,i-1]
      else
        matrix.[n-1,i-1] <- matrix.[n-2,i-1] + matrix.[n-1,i-2]


printfn "%A" matrix.[19,19]

// unschön prozedural

// mathematische lösung ohne matrix
// (x+y)!/(x!*y!)
// für n = 20
// 40! / 20!^2 kann man durch zählerzerlegung auf dem papier rechnen