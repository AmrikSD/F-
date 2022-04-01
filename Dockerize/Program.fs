open System

let hostName = System.Net.Dns.GetHostName()


printfn $"Hello, from {hostName}"
