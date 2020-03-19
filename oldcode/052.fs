//It can be seen that the number, 125874, and its double, 251748, contain exactly the same digits, but in a different order.

//Find the smallest positive integer, x, such that 2x, 3x, 4x, 5x, and 6x, contain the same digits.

let rec intToList i =
  if i > 0 then
    List.append [i%10] (intToList (i/10))
  else
    []

let rec euler052 n =
  if ((List.sort (intToList n)) = (List.sort (intToList (2*n)))) &&
     ((List.sort (intToList n)) = (List.sort (intToList (3*n)))) &&
     ((List.sort (intToList n)) = (List.sort (intToList (4*n)))) &&
     ((List.sort (intToList n)) = (List.sort (intToList (5*n)))) &&
     ((List.sort (intToList n)) = (List.sort (intToList (6*n)))) then
    n
  else
    euler052 (n+1)

printfn "%d" (euler052 1)