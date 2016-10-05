```ini

Host Process Environment Information:
BenchmarkDotNet.Core=v0.9.9.0
OS=Windows
Processor=?, ProcessorCount=16
Frequency=2539062 ticks, Resolution=393.8462 ns, Timer=TSC
CLR=CORE, Arch=64-bit ? [RyuJIT]
GC=Concurrent Workstation
dotnet cli version: 1.0.0-preview2-003131

Type=ResourceStringsAccess  Mode=Throughput  

```
               Method |      Median |    StdDev |
--------------------- |------------ |---------- |
 StandardErrorMessage | 156.0498 ns | 0.5012 ns |
   CachedErrorMessage | 101.2649 ns | 1.9415 ns |
