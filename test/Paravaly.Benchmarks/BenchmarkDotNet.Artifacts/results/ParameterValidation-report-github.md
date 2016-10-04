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
 IsNotWhiteSpace | 126.3322 ns | 0.4504 ns |
      IsNotEmpty | 146.2557 ns | 1.3683 ns |
 |
erValidation_IsNotWhiteSpace
  ParameterValidation_IsNotEmpty
      NA |        NA |

Benchmarks with issues:
  ParameterValidation_RawIsNotEmpty
