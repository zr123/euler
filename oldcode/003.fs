//The prime factors of 13195 are 5, 7, 13 and 29.
//What is the largest prime factor of the number 600851475143 ? root = 775146

//let limit = System.Convert.ToInt64(sqrt (System.Convert.ToDouble(600851475143L)))

let rec primfaktorzerlegung primfaktoren n currentvalue =
  match List.tryFind (fun x -> n % x = 0L) [currentvalue .. (int64(sqrt(double(n))))] with
  | Some value -> (primfaktorzerlegung (List.append primfaktoren [value]) (n/value) value)
  | None -> (List.append primfaktoren [n])
  
printfn "%A"(primfaktorzerlegung [] 600851475143L 2L)
