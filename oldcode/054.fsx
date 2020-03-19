//0 •High Card: Highest value card.
//1 •One Pair: Two cards of the same value.
//2 •Two Pairs: Two different pairs.
//3 •Three of a Kind: Three cards of the same value.
//4 •Straight: All cards are consecutive values.
//5 •Flush: All cards of the same suit.
//6 •Full House: Three of a kind and a pair.
//7 •Four of a Kind: Four cards of the same value.
//8 •Straight Flush: All cards are consecutive values of same suit.
//9 •Royal Flush: Ten, Jack, Queen, King, Ace, in same suit.


open System.Text.RegularExpressions

type pokerHand (hand: string) =
  let mutable Cards = hand.Split [|' '|]
  // helpers
  member this.countOccurances (cardRegex) = 
    let mutable count = 0
    for i in Cards do
      if Regex.IsMatch (i, cardRegex) then
        count <- count + 1
    count
  
  member this.isRoyalFlush () =
    let mutable result = 0
    if (this.countOccurances ("T.") = 1) && (this.countOccurances ("J.") = 1) && (this.countOccurances ("Q.") = 1) && (this.countOccurances ("K.") = 1) && (this.countOccurances ("A.") = 1) then
      if this.countOccurances (".D") = 5 then result <- 91000
      if this.countOccurances (".H") = 5 then result <- 92000
      if this.countOccurances (".S") = 5 then result <- 93000
      if this.countOccurances (".C") = 5 then result <- 94000
    result
  
  member this.isStraightFlush () =
    
// end Sudoku class
  
let test = pokerHand ("5H 5C 6S 7S KD")
printfn "%A" (test.countOccurances ("5."))
printfn "%A" (test.isRoyalFlush ())