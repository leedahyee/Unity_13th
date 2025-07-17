```

BenchmarkDotNet v0.15.2, Windows 10 (10.0.19045.5965/22H2/2022Update)
Intel Core i5-9400F CPU 2.90GHz (Coffee Lake), 1 CPU, 6 logical and 6 physical cores
.NET SDK 9.0.201
  [Host]     : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX2


```
| Method                  | Mean     | Error    | StdDev   |
|------------------------ |---------:|---------:|---------:|
| AccumuateWithValueTask1 | 12.41 ns | 0.031 ns | 0.029 ns |
| AccumuateWithValueTask2 | 14.48 ns | 0.160 ns | 0.134 ns |
