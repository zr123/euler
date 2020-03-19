//The series, 11 + 22 + 33 + ... + 1010 = 10405071317.
//
//Find the last ten digits of the series, 11 + 22 + 33 + ... + 10001000.

open System.Numerics

let a =
  [for i in [1I..1000I] do
    yield (BigInteger.Pow (i,(int i)))]
    //yield (pown i (int i))]
  
printfn "%A" ((List.sum a) % 10000000000I)