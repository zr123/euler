//We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once; for example, the 5-digit number, 15234, is 1 through 5 pandigital.

//The product 7254 is unusual, as the identity, 39 × 186 = 7254, containing multiplicand, multiplier, and product is 1 through 9 pandigital.

//Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.
//HINT: Some products can be obtained in more than one way so be sure to only include it once in your sum.

// Copypaste von 047
let countunique l =  
  Seq.length (Seq.countBy (fun x -> x) l)


let answer = 
  [for a in [1..100] do
    for b in [a..10000] do
      let numstring = ((string a) + (string b) + (string (a*b))).ToCharArray()
      if (Array.length (Array.filter (fun x -> x <> '0') numstring)) = (Array.length numstring) then // sinnlose 0'en entfernen
        if (Array.length numstring) = 9 && (countunique numstring) = (Array.length numstring) then
          yield a*b]

printfn "%A" (Seq.sum (Seq.distinct answer))