using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;


namespace Helpers
{
    /// <summary>
    /// Helps to convert DataTable and DataSets to entities
    /// </summary>
    public abstract class ConversionHelper
    {
        #region Entity to DataSet

        /// <summary>
        /// Comverts complexts entity to data set.
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="complexType">complexType</param>
        /// <returns>DataSet with tables</returns>
        public static DataSet ComplextEntityToDataSet<T>(T complexType)
        {
            DataSet ds = new DataSet();
            PropertyInfo[] properties = complexType.GetType().GetProperties();

            foreach (PropertyInfo pi in properties)
            {
                DataTable dt = TranslateObjectTypeToDataTable(complexType, pi);
                if (dt != null)
                {
                    ds.Tables.Add(dt);
                }
            }
            return ds;
        }

        /// <summary>
        /// Comverts Lists to table.
        /// </summary>
        /// <typeparam name="T">entity type</typeparam>
        /// <param name="list">The list of entities</param>
        /// <returns>DataTable</returns>
        public static DataTable ListToTable<T>(IList<T> list)
        {
            string tableName = AttributeReader.GetBoundTable(list[0]);
            DataTable table = new DataTable(tableName);
            Exception exception = null;

            if (list.Count > 0)
            {
                PropertyInfo[] properties = list[0].GetType().GetProperties();
                List<string> columns = new List<string>();

                try
                {
                    foreach (PropertyInfo pi in properties)
                    {
                        object[] coll = pi.GetCustomAttributes(typeof (FieldDataColumn), true);
                        FieldDataColumn objBoundColumn = (FieldDataColumn) coll[0];
                        table.Columns.Add(objBoundColumn.ColumnName);
                        columns.Add(objBoundColumn.ColumnName);
                    }

                    foreach (T item in list)
                    {
                        object[] cells = GetValues(columns, item);
                        table.Rows.Add(cells);
                    }
                }
                catch (ArgumentNullException ane)
                {
                    ane.Log(typeof(T).ToString(), LogConstants.EVENT_CATEGORY_ADAPTER_UI);
                    exception = ane;
                }
                catch (ArgumentException ae)
                {
                    ae.Log(typeof(T).ToString(), LogConstants.EVENT_CATEGORY_ADAPTER_UI);
                    exception = ae;
                }
                catch (ConstraintException ce)
                {
                    exception = ce;
                }
                catch (TargetException te)
                {
                    te.Log(typeof(T).ToString(), LogConstants.EVENT_CATEGORY_ADAPTER_UI);
                    exception = te;
                }
                catch (TargetParameterCountException tpce)
                {
                    exception = tpce;
                }
                catch (MemberAccessException mae)
                {
                    exception = mae;
                }
                catch (NoNullAllowedException nnae)
                {
                    nnae.Log(typeof(T).ToString(), LogConstants.EVENT_CATEGORY_ADAPTER_UI);
                    exception = nnae;
                }
                catch (TargetInvocationException tie)
                {
                    tie.Log(typeof(T).ToString(), LogConstants.EVENT_CATEGORY_ADAPTER_UI);
                    exception = tie;
                }
                catch (InvalidCastException ice)
                {
                    ice.Log(typeof(T).ToString(), LogConstants.EVENT_CATEGORY_ADAPTER_UI);
                    exception = ice;
                }
                catch (AdapterUserInterfacesExceptions auiex)
                {
                    auiex.Log(typeof(T).ToString(), LogConstants.EVENT_CATEGORY_ADAPTER_UI);
                    exception = auiex;
                }
            }

            if(exception != null)
            {
                throw exception;
            }
            return table;
        }

        /// <summary>
        /// Mapping method -> List property of complex type to entity
        /// </summary>
        /// <param name="complexItem">The complex item.</param>
        /// <param name="property">The pi.</param>
        /// <returns>DataTable</returns>
        protected static DataTable TranslateObjectTypeToDataTable(object complexItem, PropertyInfo property)
        {
            DataTable dt = null;
            object val = property.GetValue(complexItem, null);

            if (property.PropertyType == typeof(List<Person>))
            {
                dt = ListToTable<Person>((IList<Person>)val);
            }
            else if (property.PropertyType == typeof(List<Letters>))
            {
                dt = ListToTable<Letters>((IList<Letters>)val);
            }

            return dt;
        } 
        
        #endregion

        #region DataSet to Entity

        /// <summary>
        /// Converts the data set to complex entity.
        /// </summary>
        /// <typeparam name="T">entity type</typeparam>
        /// <param name="dataSet">DataSet</param>
        /// <returns>item</returns>
        public static T ConvertDataSetToComplexEntity<T>(DataSet dataSet) where T : class, new()
        {
            T item = new T();

            foreach (DataTable dt in dataSet.Tables)
            {
                TableMappingToEntity(dt, item);
            }

            return item;
        }

        /// <summary>
        /// Mapping the table names to entities
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <param name="item">The item.</param>
        protected static void TableMappingToEntity(DataTable dataTable, object item)
        {
            if (dataTable.TableName == "People22")
            {
                SetListInItem(GetItemsList<Person>(dataTable), "persons", item);
            }
            else if (dataTable.TableName == "letters")
            {
                SetListInItem(GetItemsList<Letters>(dataTable), "letters", item);
            }
        }

        /// <summary>
        /// DataTable to entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataSet">will get the first table</param>
        /// <returns></returns>
        public static List<T> DataSetToList<T>(DataSet dataSet) where T : class, new()
        {
            return DataTableToList<T>(dataSet.Tables[0]);
        } 

        /// <summary>
        /// DataTable to entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataTable">The obj table.</param>
        /// <returns></returns>
        public static List<T> DataTableToList<T>(DataTable dataTable) where T : class, new()
        {
            Exception exception = null;
            List<T> results = new List<T>();
            T item = new T();

            try
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (PropertyInfo objField in typeof (T).GetProperties())
                    {
                        string strColumnName = AttributeReader.GetBoundColumn(item, objField.Name);
                        objField.SetValue(item, Convert.ChangeType(row[strColumnName], objField.PropertyType), null);
                    }
                    results.Add(item);
                }
            }
            catch (ArgumentNullException ane)
            {
                ane.Log(typeof(T).ToString(), LogConstants.EVENT_CATEGORY_ADAPTER_SESSION_OBJECTS);
                exception = ane;
            }
            catch (ArgumentException ae)
            {
                ae.Log(typeof(T).ToString(), LogConstants.EVENT_CATEGORY_ADAPTER_SESSION_OBJECTS);
                exception = ae;
            }
            catch (ConstraintException ce)
            {
                exception = ce;
            }
            catch (TargetException te)
            {
                te.Log(typeof(T).ToString(), LogConstants.EVENT_CATEGORY_ADAPTER_SESSION_OBJECTS);
                exception = te;
            }
            catch (TargetParameterCountException tpce)
            {
                exception = tpce;
            }
            catch (MemberAccessException mae)
            {
                exception = mae;
            }
            catch (NoNullAllowedException nnae)
            {
                nnae.Log(typeof(T).ToString(), LogConstants.EVENT_CATEGORY_ADAPTER_SESSION_OBJECTS);
                exception = nnae;
            }
            catch (TargetInvocationException tie)
            {
                tie.Log(typeof(T).ToString(), LogConstants.EVENT_CATEGORY_ADAPTER_SESSION_OBJECTS);
                exception = tie;
            }
            catch (InvalidCastException ice)
            {
                ice.Log(typeof(T).ToString(), LogConstants.EVENT_CATEGORY_ADAPTER_SESSION_OBJECTS);
                exception = ice;
            }
            catch (AdapterUserInterfacesExceptions auiex)
            {
                auiex.Log(typeof(T).ToString(), LogConstants.EVENT_CATEGORY_ADAPTER_SESSION_OBJECTS);
                exception = auiex;
            }

            if(exception != null)
            {
                throw exception;
            }

            return results;
        }

        #endregion

        #region Helpers methods

        /// <summary>
        /// Sets the proper list property in complex entity
        /// </summary>
        /// <param name="list">The list of items</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="lookIn">complex entity</param>
        protected static void SetListInItem(IList list, string propertyName, object lookIn)
        {
            foreach (PropertyInfo objField in lookIn.GetType().GetProperties())
            {
                if (objField.Name == propertyName)
                {
                    objField.SetValue(lookIn, Convert.ChangeType(list, objField.PropertyType), null);
                }

            }

        }

        /// <summary>
        /// Gets the items list.
        /// </summary>
        /// <typeparam name="T">enity type</typeparam>
        /// <param name="dataTable">DataTable</param>
        /// <returns>list of items</returns>
        protected static List<T> GetItemsList<T>(DataTable dataTable) where T : class, new()
        {
            List<T> result = new List<T>();

            foreach (DataRow objRow in dataTable.Rows)
            {
                T objPerson = new T();

                foreach (PropertyInfo objField in typeof(T).GetProperties())
                {
                    string strColumnName = AttributeReader.GetBoundColumn(objPerson, objField.Name);
                    objField.SetValue(objPerson, Convert.ChangeType(objRow[strColumnName], objField.PropertyType), null);
                }
                result.Add(objPerson);
            }

            return result;
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <param name="columns">list of columns.</param>
        /// <param name="instance">entity instance</param>
        /// <returns>values</returns>
        protected static object[] GetValues(List<string> columns, object instance)
        {
            object[] ret = new object[columns.Count];

            for (int n = 0; n < ret.Length; n++)
            {
                PropertyInfo pi = instance.GetType().GetProperty(columns[n]);
                object value = pi.GetValue(instance, null);
                ret[n] = value;
            }

            return ret;
        } 

        #endregion
    }
}
