#load "Eulerlib.fs"

//for i in [987654321..-2..900000000] do
//  let test = string i
//  if test.Contains("1") && test.Contains("2") && test.Contains("3") && test.Contains("4") && test.Contains("5") && test.Contains("6") && test.Contains("7") && test.Contains("8") && test.Contains("9") && (isprime i) > 0 then
//    printfn "%d" i

let rec bs i =
  let test = string i
  if test.Contains "1" && test.Contains "2" && test.Contains "3" && test.Contains "4" && test.Contains "5" && test.Contains "6" && test.Contains "7" && Eulerlib.isprime i then
    i
  else
    bs (i-2)

printfn "%A" (bs 7654321)

// only 7 digits, refactor for n=8 or n=9, even tho there is no point ...