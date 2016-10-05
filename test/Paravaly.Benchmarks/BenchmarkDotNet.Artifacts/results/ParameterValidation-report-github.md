```ini

Host Process Environment Information:
BenchmarkDotNet.Core=v0.9.9.0
OS=Windows
Processor=?, ProcessorCount=16
Frequency=2539062 ticks, Resolution=393.8462 ns, Timer=TSC
CLR=CORE, Arch=64-bit ? [RyuJIT]
GC=Concurrent Workstation
dotnet cli version: 1.0.0-preview2-003131

Type=ParameterValidation  Mode=Throughput  

```
          Method |      Median |     StdDev |
---------------- |------------ |----------- |
      IsNotEmpty | 126.3836 ns | 17.9519 ns |
 IsNotWhiteSpace | 114.7710 ns |  0.3318 ns |
