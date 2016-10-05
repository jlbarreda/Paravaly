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
---------------- |------------ |---------- |
 IsNotWhiteSpace | 311.3071 ns | 2.5425 ns |
      IsNotEmpty | 295.8326 ns | 1.6656 ns |
 LocalIsNotEmpty |  79.8310 ns | 0.3608 ns |
alidation_IsNotEmpty
      NA |        NA |

Benchmarks with issues:
  ParameterValidation_RawIsNotEmpty
