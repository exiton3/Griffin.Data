﻿using System;
using Griffin.Data.BasicLayer;

namespace Griffin.Data.Mappings
{
    /// <summary>
    /// Converts from SqlServer min date (1753) to <c>DateTime.MinValue</c> if required.
    /// </summary>
    public class SqlServerDateConverter : IColumnConverter
    {
        /// <summary>
        /// Convert from db value to property value
        /// </summary>
        /// <param name="dbColumnValue">Value in the db column</param>
        /// <returns>Value which can be assigned to the property</returns>
        public object ConvertFromDb(object dbColumnValue)
        {
            if(dbColumnValue == DBNull.Value)
                return DateTime.MinValue;

            var dateTime = (DateTime) dbColumnValue;
            return dateTime.FromSqlServer();
        }
    }
}
