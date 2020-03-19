//open System.IO

let intArray = ((System.IO.File.ReadAllLines("059.txt").[0].Split ',') |> Array.map int)

let validateCharRange i =
  if (i >= 97 && i <= 126) || (i >= 65 && i <= 90) || (i = 32) then
    true
  else
    false

let decipher a initialValue char =
  let mutable r = Array.copy a
  let mutable i = initialValue
  let mutable check = 0;
  while i < Array.length r do  
    r.[i] <- r.[i] ^^^ (int char)
    if not (validateCharRange r.[i]) then
      check <- check + 1
    i <- i+3  
  if check < 50 then
    r
  else
    [||]

 
for a in 97 .. 122 do
  let l1 = (decipher intArray 0 (char a))
  if l1 <> [||] then
    for b in 97 .. 122 do 
      let l2 = (decipher l1 1 (char b))
      if l2 <> [||] then
        for c in 97 .. 122 do 
          let l3 = (decipher l2 2 (char c))
          if l3 <> [||] then 
            //printfn "key: %A%A%A" (char a) (char b) (char c)
            printfn "%A" (Array.sum l3)
            //printfn "Actual Text:\n%A" (System.String (Array.map char l3))