using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using Ylvis.Utils.Features.ExtendentEnum;

namespace Ylvis.Winforms
{
    #region class EnumHelper
    /// <summary>
    /// Provides a static utility object of methods and properties to interact with enumerated types. 
    /// </summary>
    public static class EnumHelper
    {
        public static T GetEnumValueFromCombo<T>(this ComboBox combo) where T : struct
        {
            T status;
            Enum.TryParse<T>(combo.SelectedValue.ToString(), out status);
            return status;
        }
        public static T GetEnumValueFromComboSafe<T>(this ComboBox combo, T def) where T : struct
        {
            T status = def;
            try
            {
                Enum.TryParse<T>(combo.SelectedValue.ToString(), out status);
            }
            catch (Exception)
            {
            }
            return status;
        }
        
        /// <summary>
        /// Gets the <see cref="DescriptionAttribute"/> of an <see cref="Enum"/> type value.
        /// </summary>
        /// <param name="value">The <see cref="Enum"/> type value.</param>
        /// <returns>A string containing the text of the <see cref="DescriptionAttribute"/>.</returns>
        public static string GetDescription(this Enum value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            string description = value.ToString();
            FieldInfo fieldInfo = value.GetType().GetField(description);
            EnumDescriptionAttribute[] attributes = (EnumDescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                description = attributes[0].Description;
            }
            return description;
        }
        #endregion

        /// <summary>
        ///  Converts the <see cref="Enum"/> type to an <see cref="IList"/> compatible object.
        /// </summary>
        /// <param name="type">The <see cref="Enum"/> type.</param>
        /// <returns>An <see cref="IList"/> containing the enumerated type value and description.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter",
            Justification = "This is a more advanced use of the ToList function; providing a type parameter has no semantic meaning for this function and would actually make the calling syntax more complicated.")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static IList ToExtendedList<T>(this Type type, bool getDescription = true)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            if (!type.IsEnum)
            {
                throw new ArgumentException("ArgumentExceptionMustBeEnum", "type");
            }

            ArrayList list = new ArrayList();
            Array enumValues = Enum.GetValues(type);

            foreach (Enum value in enumValues)
            {
                //string description = (getDescription) ? GetDescription(value) : value.ToString();
                T typ = (T) Convert.ChangeType(value, typeof (T), CultureInfo.InvariantCulture);
                list.Add(new KeyValueTriplet<Enum, T, string>(value, typ, GetDescription(value)));
            }

            return list;
        }

        /// <summary>
        ///  Converts the <see cref="Enum"/> type to an <see cref="IList"/> compatible object.
        /// </summary>
        /// <param name="type">The <see cref="Enum"/> type.</param>
        /// <returns>An <see cref="IList"/> containing the enumerated type value and description.</returns>
        public static IList ToList(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            if (!type.IsEnum)
            {
                throw new ArgumentException("ArgumentExceptionMustBeEnum", "type");
            }

            ArrayList list = new ArrayList();
            Array enumValues = Enum.GetValues(type);

            foreach (Enum value in enumValues)
            {
                list.Add(new KeyValuePair<Enum, string>(value, GetDescription(value)));
            }

            return list;
        }
        
        /// <summary>
        ///  Converts the <see cref="Enum"/> type to an <see cref="IList"/> compatible object.
        /// </summary>
        /// <param name="type">The <see cref="Enum"/> type.</param>
        /// <returns>An <see cref="IList"/> containing the enumerated type value and description.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter",
            Justification = "This is a more advanced use of the ToList function; providing a type parameter has no semantic meaning for this function and would actually make the calling syntax more complicated.")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static IList ToList<T>(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            if (!type.IsEnum)
            {
                throw new ArgumentException("ArgumentExceptionMustBeEnum", "type");
            }

            ArrayList list = new ArrayList();
            Array enumValues = Enum.GetValues(type);

            foreach (Enum value in enumValues)
            {
                list.Add(new KeyValuePair<T, string>((T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture), GetDescription(value)));
            }

            return list;
        }
    }
}
