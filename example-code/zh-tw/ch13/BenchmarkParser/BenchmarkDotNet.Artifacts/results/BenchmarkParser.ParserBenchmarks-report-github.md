```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.9278/25H2/2025Update/HudsonValley2)
12th Gen Intel Core i7-12700H 2.30GHz, 1 CPU, 20 logical and 14 physical cores
.NET SDK 10.0.303
  [Host]     : .NET 10.0.11 (10.0.11, 10.0.1126.37416), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.11 (10.0.11, 10.0.1126.37416), X64 RyuJIT x86-64-v3


```
| Method           | Mean     | Error    | StdDev   | Median   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------- |---------:|---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| SubstringParsing | 18.22 ns | 1.224 ns | 3.610 ns | 20.11 ns |  1.06 |    0.36 | 0.0025 |      32 B |        1.00 |
| SpanParsing      | 12.93 ns | 0.190 ns | 0.178 ns | 13.01 ns |  0.75 |    0.20 |      - |         - |        0.00 |
