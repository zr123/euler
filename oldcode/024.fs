//A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4. If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:

//012   021   102   120   201   210

//What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?

// There are 5 valid permutations of list1, with n from 0 to 4.

printfn "%d" 2783915460L 

//  9! == Fakultät von 9; R = Rest der ganzzahligen division; [liste der unverwendeten ziffern]

// Wir renehmen 999999 statt 1000000 weil projecteuler mit 1 anfängt zu zählen (>.<)

//  999999  / 9! = 2 R 274239   [0123456789] => 2
//  274239  / 8! = 6 R 32319    [013456789] => 27
//  32319   / 7! = 6 R 2079     [01345689] => 278
//  2079    / 6! = 2 R 639      [0134569] => 2783
//  639     / 5! = 5 R 39       [014569] => 27839
//  39      / 4! = 1 R 15       [01456] => 278391
//  15      / 3! = 2 R 3        [0456] => 2783915
//  3       / 2! = 1 R 1        [046] => 27839154
//  1       / 1! = 1 R 0        [06] => 278391546
//  0       / 0! = 0 R 0        [0] => 2783915460

//  A: 2783915460