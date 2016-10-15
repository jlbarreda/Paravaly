```ini

Host Process Environment Information:
BenchmarkDotNet.Core=v0.9.9.0
OS=Windows
Processor=?, ProcessorCount=4
Frequency=2433502 ticks, Resolution=410.9304 ns, Timer=TSC
CLR=CORE, Arch=64-bit ? [RyuJIT]
GC=Concurrent Workstation
dotnet cli version: 1.0.0-preview2-003131

Type=StringValidations  Mode=Throughput  

```
                Method |      Median |     StdDev |
---------------------- |------------ |----------- |
            IsNotEmpty |  33.8763 ns |  2.9750 ns |
       IsNotWhiteSpace |  35.4394 ns |  1.5822 ns |
      IsNotNullOrEmpty |  69.4131 ns |  3.2140 ns |
 IsNotNullOrWhiteSpace | 111.9479 ns | 16.0094 ns |
