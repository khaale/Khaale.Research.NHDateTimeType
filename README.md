# NHDateTimeType

Performance of a standard NHibernate [DateTimeType.IsEqual](https://github.com/nhibernate/nhibernate-core/blob/master/src/NHibernate/Type/DateTimeType.cs) 
vs [TimestampType.IsEqual](https://github.com/nhibernate/nhibernate-core/blob/master/src/NHibernate/Type/TimestampType.cs) (just as an example of desirable performance)
vs [custom implementation](https://github.com/khaale/NHDateTimeType/blob/master/NHTypes/CustomDateTimeType.cs).
Poor DateTimeType performance seems to be caused by  
```cs
			return (date1.Year == date2.Year &&
					date1.Month == date2.Month &&
					date1.Day == date2.Day &&
					date1.Hour == date2.Hour &&
					date1.Minute == date2.Minute &&
					date1.Second == date2.Second);
```

Benchmark results

```ini
BenchmarkDotNet=v0.7.8.0
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i5-3470 CPU @ 3.20GHz, ProcessorCount=4
HostCLR=MS.NET 4.0.30319.34209, Arch=32-bit
Type=DateTimeTypesBenchmark  Mode=Throughput  Platform=HostPlatform  Jit=HostJit  .NET=HostFramework
```

                     Method |     AvrTime |    StdDev |          op/s |
--------------------------- |------------ |---------- |-------------- |
 CustomDateTimeType_IsEqual |  46.9243 ns | 0.3065 ns | 21,310,917.78 |
       DateTimeType_IsEqual | 281.2075 ns | 1.4330 ns |  3,556,096.26 |
      TimestampType_IsEqual |  20.2574 ns | 0.1129 ns | 49,364,775.15 |
