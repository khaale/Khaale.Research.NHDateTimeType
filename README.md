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
