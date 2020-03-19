let fak = [|1;1;2;6;24;120;720;5040;40320;362880|]

let rec digfacsum num =
  if num > 0 then
    (fak.[num%10] + (digfacsum (num/10)))
  else
    0

printfn "%A" (List.sum (List.filter (fun x -> x = digfacsum x) [3..3000000]))