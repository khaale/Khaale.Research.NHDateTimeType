using System;
using System.Data;
using NHibernate.Dialect;
using NHibernate.SqlTypes;
using NHibernate.Type;

namespace NHTypes
{
    public class CustomDateTimeType : PrimitiveType
    {

        public CustomDateTimeType() : base(SqlTypeFactory.DateTime)
        {
        }

        public override bool IsEqual(object x, object y)
        {
            if (x == y)
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            DateTime date1 = (DateTime)x;
            DateTime date2 = (DateTime)y;

            if (date1.Equals(date2))
                return true;

            //A single tick represents one hundred nanoseconds or one ten-millionth of a second. There are 10,000 ticks in a millisecond. (c) MSDN
            //So there are 10^7 ticks in a second
            return Math.Abs(Math.Floor(date1.Ticks * 1E-07) - Math.Floor(date2.Ticks * 1E-07)) < 1;
        }

        #region Stubs

        public override void Set(IDbCommand cmd, object value, int index)
        {
            throw new NotImplementedException();
        }

        public override object Get(IDataReader rs, int index)
        {
            throw new NotImplementedException();
        }

        public override object Get(IDataReader rs, string name)
        {
            throw new NotImplementedException();
        }

        public override object FromStringValue(string xml)
        {
            throw new NotImplementedException();
        }

        public override string Name
        {
            get { throw new NotImplementedException(); }
        }

        public override Type ReturnedClass
        {
            get { throw new NotImplementedException(); }
        }

        public override string ObjectToSQLString(object value, Dialect dialect)
        {
            throw new NotImplementedException();
        }

        public override Type PrimitiveClass
        {
            get { throw new NotImplementedException(); }
        }

        public override object DefaultValue
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}