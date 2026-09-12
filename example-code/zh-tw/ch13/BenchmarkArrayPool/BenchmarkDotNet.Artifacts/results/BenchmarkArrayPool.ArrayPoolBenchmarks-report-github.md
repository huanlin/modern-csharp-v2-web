```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.9278/25H2/2025Update/HudsonValley2)
12th Gen Intel Core i7-12700H 2.30GHz, 1 CPU, 20 logical and 14 physical cores
.NET SDK 10.0.303
  [Host]     : .NET 10.0.11 (10.0.11, 10.0.1126.37416), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.11 (10.0.11, 10.0.1126.37416), X64 RyuJIT x86-64-v3


```
| Method              | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------- |----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| NewArray            | 119.47 ns | 2.531 ns | 6.624 ns |  1.00 |    0.07 | 0.3281 |    4120 B |        1.00 |
| ArrayPoolRentReturn |  10.51 ns | 0.048 ns | 0.040 ns |  0.09 |    0.00 |      - |         - |        0.00 |
