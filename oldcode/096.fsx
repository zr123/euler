// Su Doku (Japanese meaning number place) is the name given to a popular puzzle concept. Its origin is unclear, but credit must be attributed to Leonhard Euler who invented a similar, and much more difficult, puzzle idea called Latin Squares. The objective of Su Doku puzzles, however, is to replace the blanks (or zeros) in a 9 by 9 grid in such that each row, column, and 3 by 3 box contains each of the digits 1 to 9. Below is an example of a typical starting puzzle grid and its solution grid.
//A well constructed Su Doku puzzle has a unique solution and can be solved by logic, although it may be necessary to employ "guess and test" methods in order to eliminate options (there is much contested opinion over this). The complexity of the search determines the difficulty of the puzzle; the example above is considered easy because it can be solved by straight forward direct deduction.

//The 6K text file, sudoku.txt (right click and 'Save Link/Target As...'), contains fifty different Su Doku puzzles ranging in difficulty, but all with unique solutions (the first puzzle in the file is the example above).

//By solving all fifty puzzles find the sum of the 3-digit numbers found in the top left corner of each solution grid; for example, 483 is the 3-digit number found in the top left corner of the solution grid above.

type Field (n: int) as self = 
  [<DefaultValue>] val mutable Number: int
  [<DefaultValue>] val mutable Possibilities: int list
  do
    if n = 0 then
      self.Number <- 0
      self.Possibilities <- [1; 2; 3; 4; 5; 6; 7; 8; 9]
    else
      self.Number <- n
      self.Possibilities <- []

  member this.removePossibility (filter: int) =
    this.Possibilities <- List.filter (fun p -> p <> filter) this.Possibilities
  
  member this.setToNumber (number: int) =
    this.Number <- number
    this.Possibilities <- []
  
  // 0 = nothing; >0 = possibility found; -1 = problem
  member this.checkPossibilities () =
    if List.length this.Possibilities = 0 && this.Number = 0 then
      -1
    else
      if List.length this.Possibilities = 1 then
        List.head this.Possibilities
      else
        0
//end Field class  
      
type Sudoku() = 
  let mutable Field: Field [,] = Array2D.init 9 9 (fun i j -> Field 0)

  member this.setField (input: string array) =
    for row = 0 to 8 do
      for col = 0 to 8 do
        Field.[row,col] <- new Field (int input.[row].[col] - 48)
    for row = 0 to 8 do
      for col = 0 to 8 do
        this.filterRow (row, Field.[row, col].Number)
        this.filterCol (col, Field.[row, col].Number)
        this.filterBlock (row, col, Field.[row, col].Number)
        
  member this.getField () =
    let s: string[] = Array.init 9 (fun x -> "")
    for row = 0 to 8 do
      for col = 0 to 8 do
        s.[row] <- s.[row] + sprintf "%i" Field.[row, col].Number
      s.[row] <- s.[row] + sprintf "\n"
    s      
    
  member this.filterRow (row: int, filter: int) =
    for col in 0..8 do
      Field.[row, col].removePossibility filter

  member this.filterCol (col: int, filter: int) =
    for row in 0..8 do
      Field.[row, col].removePossibility filter
  
  member this.filterBlock (row: int, col: int, filter: int) =
    for r = (row/3)*3 to (row/3)*3 + 2 do
      for c = (col/3)*3 to (col/3)*3 + 2 do
        Field.[r, c].removePossibility filter
  
  member this.setNumberAndApplyFilters (row: int, col: int, number: int) =
    Field.[row, col].setToNumber number
    this.filterRow (row, Field.[row, col].Number)
    this.filterCol (col, Field.[row, col].Number)
    this.filterBlock (row, col, Field.[row, col].Number)
    

  // Analyze a Block if there is a Field which is the only possible location for a Number (because none of the remaining fields in the block can be that number)
  member this.analyzeBlock (row: int, col: int) =
    let mutable success = false
    let possibilityCount = Array.zeroCreate 10
    for r = (row/3)*3 to (row/3)*3 + 2 do
      for c = (col/3)*3 to (col/3)*3 + 2 do
        for l in Field.[r, c].Possibilities do
          possibilityCount.[l] <- possibilityCount.[l] + 1
    for i = 0 to 9 do
      if possibilityCount.[i] = 1 then
        for r = (row/3)*3 to (row/3)*3 + 2 do
          for c = (col/3)*3 to (col/3)*3 + 2 do
            for l in Field.[r, c].Possibilities do
              if i = l then
                this.setNumberAndApplyFilters (r, c, l)
                success <- true
    success
  
  member this.isSolved () =
    let mutable solved = true
    for row = 0 to 8 do
      for col = 0 to 8 do
        if Field.[row, col].Number = 0 then
          solved <- false
    solved
  
  member this.trySolve () =
    let mutable exitCode = 0
    for row = 0 to 8 do
      for col = 0 to 8 do
        let num = Field.[row, col].checkPossibilities ()
        if num = -1 then
          exitCode <- -1
        if num > 0 && exitCode <> -1 then
          this.setNumberAndApplyFilters (row, col, num)
          exitCode <- 1
    for r in [0..3..6] do
      for c in [0..3..6] do
        if this.analyzeBlock (r, c) && exitCode <> -1 then
          exitCode <- 1
    exitCode
  
  member this.solveLooper () =
    let mutable exitCode = 1
    while exitCode = 1 do
      exitCode <- this.trySolve ()
    exitCode
    
  member this.solve () =
    let mutable i = this.solveLooper () // = 0
    while not (this.isSolved ()) && i < 81 do
      while i < 81 && Field.[i/9, i%9].Number <> 0 do
        i <- i + 1
      for p in Field.[i/9, i%9].Possibilities do
        let trailField = Sudoku ()
        trailField.setField (this.getField ())
        trailField.setNumberAndApplyFilters (i/9, i%9, p)
        if trailField.solveLooper () = -1 then 
          Field.[i/9, i%9].removePossibility p
      ignore (this.solveLooper ())
      i <- i + 1
  
  member this.returnProjectEulerNumber () =
    Field.[0, 0].Number * 100 + Field.[0, 1].Number * 10 + Field.[0, 2].Number
// end Sudoku class


let file = System.IO.File.ReadAllLines "096.txt"
let mutable sum = 0
for i in [0 .. 10 .. 490] do 
  let field = Sudoku ()
  field.setField file.[i+1 .. i+9]
  field.solve ()
  sum <- sum + (field.returnProjectEulerNumber ())

printfn "%A" sum