//In England the currency is made up of pound, £, and pence, p, and there are eight coins in general circulation:
//
//    1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).
//
//It is possible to make £2 in the following way:
//
//    1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p
//
//How many different ways can £2 be made using any number of coins?

//brute force
let mutable count = 1
for pound = 0 to 2 do 
  for halfpound = 0 to 4 do 
    for twenty = 0 to 10 do
      for ten = 0 to 20 do 
        for five = 0 to 40 do
          for two = 0 to 100 do
            if (pound*100 + halfpound*50 + twenty*20 + ten*10 + five*5 + two*2) <= 200 then 
              count <- count+1

printfn "%d" count