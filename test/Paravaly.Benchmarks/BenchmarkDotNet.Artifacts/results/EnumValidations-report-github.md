```ini

Host Process Environment Information:
BenchmarkDotNet.Core=v0.9.9.0
OS=Windows
Processor=?, ProcessorCount=4
Frequency=2433502 ticks, Resolution=410.9304 ns, Timer=TSC
CLR=CORE, Arch=64-bit ? [RyuJIT]
GC=Concurrent Workstation
dotnet cli version: 1.0.0-preview2-003131

Type=EnumValidations  Mode=Throughput  

```
           Method |      Median |     StdDev |
----------------- |------------ |----------- |
 IsValidEnumValue | 664.4641 ns | 67.4453 ns |
