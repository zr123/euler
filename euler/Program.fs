﻿open Euler001
open Euler002
open Euler003
open Euler004
open Euler005
open Euler006
open Euler007
open System
open System.Reflection


let callFunction name = 
    let asm = Assembly.GetExecutingAssembly()
    for t in asm.GetTypes() do
        for m in t.GetMethods() do
            if m.IsStatic && m.Name = name then 
                printfn "%A" (m.Invoke(null, [||]))
    
   

[<EntryPoint>]
let main argv = 
    if Array.length argv > 0 then
        callFunction argv.[0]
    0
