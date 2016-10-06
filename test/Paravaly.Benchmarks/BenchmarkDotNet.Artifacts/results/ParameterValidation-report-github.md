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
                Method |      Median |    StdDev |
---------------------- |------------ |---------- |
            IsNotEmpty | 107.8067 ns | 1.1202 ns |
       IsNotWhiteSpace | 112.1737 ns | 0.6278 ns |
      IsNotNullOrEmpty | 138.5465 ns | 6.8998 ns |
 IsNotNullOrWhiteSpace | 171.0733 ns | 0.7358 ns |
