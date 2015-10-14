using System;
using BenchmarkDotNet;
using BenchmarkDotNet.Tasks;
using NHibernate.Type;
using NHTypes;

namespace DateTimeTypeBenchmark
{
    [BenchmarkTask()]
    public class DateTimeTypesBenchmark
    {
        private static readonly DateTime DateTime1 = new DateTime(2015, 01, 01);
        private static readonly DateTime DateTime2 = new DateTime(2015, 01, 02);

        private static readonly DateTimeType TargetDateTimeType = new DateTimeType();
        private static readonly TimestampType TargetTimestampType = new TimestampType();
        private static readonly CustomDateTimeType TargetCustomDateTimeType = new CustomDateTimeType();

        [Benchmark]
        public bool DateTimeType_IsEqual()
        {
            return TargetDateTimeType.IsEqual(DateTime1, DateTime2);
        }

        [Benchmark]
        public bool TimestampType_IsEqual()
        {
            return TargetTimestampType.IsEqual(DateTime1, DateTime2);
        }

        [Benchmark]
        public bool CustomDateTimeType_IsEqual()
        {
            return TargetCustomDateTimeType.IsEqual(DateTime1, DateTime2);
        }
    }
}
