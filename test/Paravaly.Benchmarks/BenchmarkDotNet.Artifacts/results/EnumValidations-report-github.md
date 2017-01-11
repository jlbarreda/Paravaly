```ini

Host Process Environment Information:
BenchmarkDotNet.Core=v0.9.9.0
OS=Windows
Processor=?, ProcessorCount=16
Frequency=2539060 ticks, Resolution=393.8465 ns, Timer=TSC
CLR=CORE, Arch=64-bit ? [AttachedDebugger] [RyuJIT]
GC=Concurrent Workstation
dotnet cli version: 1.0.0-preview2-003156

Type=EnumValidations  Mode=Throughput  

```
              Method |        Median |     StdDev |
-------------------- |-------------- |----------- |
    IsValidEnumValue |    97.2921 ns |  0.5499 ns |
 IsNotValidEnumValue | 7,392.7837 ns | 68.1151 ns |
