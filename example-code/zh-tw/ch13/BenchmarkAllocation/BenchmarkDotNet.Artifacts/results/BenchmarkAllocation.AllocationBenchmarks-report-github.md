```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.9278/25H2/2025Update/HudsonValley2)
12th Gen Intel Core i7-12700H 2.30GHz, 1 CPU, 20 logical and 14 physical cores
.NET SDK 10.0.303
  [Host]     : .NET 10.0.11 (10.0.11, 10.0.1126.37416), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.11 (10.0.11, 10.0.1126.37416), X64 RyuJIT x86-64-v3


```
| Method                   | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| HeapAllocation           | 120.54 ns | 2.081 ns | 1.947 ns |  1.00 |    0.02 | 0.0427 |     536 B |        1.00 |
| StackAllocation          |  84.63 ns | 0.702 ns | 0.656 ns |  0.70 |    0.01 |      - |         - |        0.00 |
| CollectionExpressionSpan | 120.53 ns | 1.811 ns | 1.694 ns |  1.00 |    0.02 | 0.0427 |     536 B |        1.00 |
