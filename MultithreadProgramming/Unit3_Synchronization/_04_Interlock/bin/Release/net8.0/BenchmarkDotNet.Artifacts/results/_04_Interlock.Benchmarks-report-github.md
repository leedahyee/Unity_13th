```

BenchmarkDotNet v0.15.2, Windows 10 (10.0.19045.5965/22H2/2022Update)
Intel Core i5-9400F CPU 2.90GHz (Coffee Lake), 1 CPU, 6 logical and 6 physical cores
.NET SDK 9.0.201
  [Host]     : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX2


```
| Method               | Mean      | Error     | StdDev    |
|--------------------- |----------:|----------:|----------:|
| Workload_Interlocked | 22.755 ms | 0.0701 ms | 0.0585 ms |
| Workload_Locked      |  6.994 ms | 0.0322 ms | 0.0285 ms |
