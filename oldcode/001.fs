//If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
//Find the sum of all the multiples of 3 or 5 below 1000.

let euler001 x =
  List.filter (fun c -> (c % 3 = 0) || (c % 5 = 0)) x
  |> List.sum

printfn "%d" (euler001 [0..999])

printfn "%d" ([0..999]
|> List.filter (fun c -> (c % 3 = 0) || (c % 5 = 0))
|> List.sum)

[0..999]
|> List.filter (fun c -> (c % 3 = 0) || (c % 5 = 0))
|> List.sum
|> printfn "%d"

printfn "%d" (List.sum (List.filter (fun c -> (c % 3 = 0) || (c % 5 = 0)) [0..999]))