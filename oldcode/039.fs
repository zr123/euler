let mutable weasel = Array.zeroCreate 1001

for a in 1.0 .. 1000.0 do
  for b in a .. 1000.0 do
    let c = sqrt (a*a + b*b)
    if c = floor c then 
      if a + b + c <= 1000.0 then
        weasel.[int (a+b+c)] <- weasel.[int (a+b+c)] + 1
        
printfn "%A" (Array.findIndex (fun x -> x = Array.max weasel) weasel)