using System;
using System.Reflection;
using SessionStateSerialization;

namespace Helpers
{
    /// <summary>
    /// Reads custom attributes from entities
    /// </summary>
    public class AttributeReader
	{
        /// <summary>
        /// Reads the ClassDataTable custom attribute from the object instance's metadata
        /// and returns the table name within the ClassDataTable
        /// </summary>
        /// <param name="targetObject">The obj target.</param>
        /// <returns>table name</returns>
		public static string GetBoundTable(object targetObject)
		{
			Type objType = targetObject.GetType();
			ClassDataTable objBoundTable = (ClassDataTable)objType.GetCustomAttributes(typeof(ClassDataTable),true)[0];

			return objBoundTable.TableName;
		}

        /// <summary>
        ///Reads the FieldDataColumn custom attribute from the object instance's metadata
        ///and returns the column name within the FieldDataTable
        /// </summary>
        /// <param name="targetObject">The obj target.</param>
        /// <param name="fieldName">Name of the STR field.</param>
        /// <returns>column name</returns>
		public static string GetBoundColumn(object targetObject, string fieldName)
		{
			Type objType = targetObject.GetType();
			PropertyInfo objField = objType.GetProperty(fieldName);
            object[] attrib = objField.GetCustomAttributes(typeof (FieldDataColumn), true);
            FieldDataColumn objBoundColumn = (FieldDataColumn)attrib[0];

			return objBoundColumn.ColumnName;
		}
	}

}

