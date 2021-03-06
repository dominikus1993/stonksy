// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open FSharp.Control
open System.Threading
// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

let test i =
    async {
        printfn $"Start i = {i}, {DateTime.Now}\n"
        do! Async.Sleep(10000 + (i * 100))
        let id = Thread.CurrentThread.ManagedThreadId;
        printfn $"End i = {i}, {DateTime.Now} -> {id}"
        return i;
    }

[<EntryPoint>]
let main argv =
    do ThreadPool.SetMinThreads(10, 100) |> ignore
    do ThreadPool.SetMaxThreads(50, 100) |> ignore
    let thrads = ThreadPool.ThreadCount
    printfn $"Threads {thrads}"
    let message = [1..10] 
                    |> List.rev 
                    |> AsyncSeq.ofSeq
                    |> AsyncSeq.mapAsyncParallel(test)
                    |> AsyncSeq.toListAsync
                    |> Async.RunSynchronously
    printfn "Hello world %A" message
    0 // return an integer exit code