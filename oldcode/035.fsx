//The number, 197, is called a circular prime because all rotations of the digits: 197, 971, and 719, are themselves prime.
//
//There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, and 97.
//
//How many circular primes are there below one million?

#load "Eulerlib.fs"

//get the rotations of an integer in digit-list form
let rec getrotations l start =
  let rot = List.append (List.tail l) [(List.head l)]
  let rot_int = (Eulerlib.listToInt rot)
  if start <> rot_int then
    List.append [rot_int] (getrotations rot start)
  else
    []

//check if all elements of subl exist in l
let rec isSubList subl l =
  if subl <> [] then
    ((List.filter (fun elem -> elem = (List.head subl)) l) <> []) && (isSubList (List.tail subl) l)
  else
    true

//calc all primes under one million
Eulerlib.calcPrimes 999999
let primes = Array.toList (Eulerlib.primes)

//do some horribly inefficient calculations
printfn "%d" (List.length (List.filter (fun x -> (isSubList (getrotations (Eulerlib.intToList x) x) primes)) primes))