using NUnit.Framework;
using System;
using System.Globalization;
using NHibernate.Type;
using NHTypes;

namespace NHibernateDateTypePerformance
{
    [TestFixture(typeof(DateTimeType))]
    [TestFixture(typeof(CustomDateTimeType))]
    public class DateTimeTypeIsEqual<T> where T : PrimitiveType
    {
        private readonly T _target;

        public DateTimeTypeIsEqual()
        {
            _target = Activator.CreateInstance<T>();
        }

        [TestCase("2015-01-01 01:01:01 000", "2015-01-01 01:01:02 000", Result = false)]
        [TestCase("2015-01-01 01:01:01 999", "2015-01-01 01:01:02 001", Result = false)]
        [TestCase("2015-01-01 01:01:01 000", "2015-01-01 01:01:01 999", Result = true)]
        public bool CustomPerSecondEquals(string dateTimeString1, string dateTimeString2)
        {
            var dt1 = DateTime.ParseExact(dateTimeString1, "yyyy-MM-dd HH:mm:ss FFF", CultureInfo.InvariantCulture);
            var dt2 = DateTime.ParseExact(dateTimeString2, "yyyy-MM-dd HH:mm:ss FFF", CultureInfo.InvariantCulture);

            return _target.IsEqual(dt1, dt2);
        }
    }
}
