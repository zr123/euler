//The number, 1406357289, is a 0 to 9 pandigital number because it is made up of each of the digits 0 to 9 in some order, but it also has a rather interesting sub-string divisibility property.

//Let d1 be the 1st digit, d2 be the 2nd digit, and so on. In this way, we note the following:

//•d2d3d4=406 is divisible by 2
//•d3d4d5=063 is divisible by 3
//•d4d5d6=635 is divisible by 5
//•d5d6d7=357 is divisible by 7
//•d6d7d8=572 is divisible by 11
//•d7d8d9=728 is divisible by 13
//•d8d9d10=289 is divisible by 17
//Find the sum of all 0 to 9 pandigital numbers with this property.

#load "Eulerlib.fs"

//creates a list of lists of all permutations of l
// hier könnte noch ein bug bezüglich führender 0'en drin sein
let rec create (l : int list) =
  let n = (List.length l) - 1
  if n > 0 then
    List.concat 
      [for i in [0 .. n] do 
        yield (List.map (fun x -> List.append [l.[i]] x) (create (List.filter (fun y -> y <> l.[i]) l)))]
  else
    [[l.[0]]]

let check1 (l : int list) = if l.[3] % 2 = 0 then true else false
let check2 (l: int list) = if (l.[2] + l.[3] + l.[4]) % 3 = 0 then true else false
let check3 (l: int list) = if l.[5] = 0 || l.[5] = 5 then true else false
let check4 (l: int list) = if (l.[4] * 100 + l.[5] * 10 + l.[6]) % 7 = 0 then true else false
let check5 (l: int list) = if (l.[5] * 100 + l.[6] * 10 + l.[7]) % 11 = 0 then true else false
let check6 (l: int list) = if (l.[6] * 100 + l.[7] * 10 + l.[8]) % 13 = 0 then true else false
let check7 (l: int list) = if (l.[7] * 100 + l.[8] * 10 + l.[9]) % 17 = 0 then true else  false
let checkall (l: int list) = if check1 l && check2 l && check3 l && check4 l && check5 l && check6 l && check7 l then true else false

printfn "%A" (List.sum (List.map (fun l -> Eulerlib.listToBigInt (List.rev l)) (List.filter checkall (create [0;1;2;3;4;5;6;7;8;9]))))