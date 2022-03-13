using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AlcaldiaAraucaPortalCommon
{
    public static class Extensiones
    {
        public static DataTable ToDataTable<T>(this List<T> items)
        {
            System.Data.DataTable returnValue = new System.Data.DataTable();
            if (items.Count > 0)
            {
                returnValue = new System.Data.DataTable(items.First().GetType().Name);
            }
            try
            {
                Type itemsType = typeof(T);
                foreach (System.Reflection.PropertyInfo prop in itemsType.GetProperties())
                {
                    System.Data.DataColumn column = new System.Data.DataColumn(prop.Name);
                    column.DataType = (Nullable.GetUnderlyingType(prop.PropertyType) == null) ? prop.PropertyType : Nullable.GetUnderlyingType(prop.PropertyType).UnderlyingSystemType;
                    returnValue.Columns.Add(column);
                }

                int j;
                foreach (T item in items)
                {
                    j = 0;
                    object[] newRow = new object[returnValue.Columns.Count];
                    foreach (System.Reflection.PropertyInfo prop in itemsType.GetProperties())
                    {
                        newRow[j] = prop.GetValue(item, null);
                        j++;
                    }
                    returnValue.Rows.Add(newRow);
                }
            }
            catch { }

            return returnValue;
        }
    }
}
