using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

namespace Ylvis.Utils.Features.TypesParsing
{
    public static class DateHelper
    {
        static Regex rgxDateSeparator = new Regex(@"(\\|-|\.)");

        public static string AdjustDateFormat(string text)
        {
            // Replace any odd date separators with the mm/dd/yyyy Standard:
            string textDate = rgxDateSeparator.Replace(text, @"/");

            if (textDate.Contains(":"))
            {
                int i = textDate.IndexOf(" ");
                textDate = textDate.Substring(0, i);
            }

            // Separate the date components as delimmited by standard mm/dd/yyyy formatting:
            string[] dateComponents = textDate.Split('/');
            string day = dateComponents[0].Trim();
            string month = dateComponents[1].Trim();
            string year = dateComponents[2].Trim();

            if (day.Length == 4)
            {
                string d = year;
                year = day;
                day = d;
            }

            // We require a two-digit month. If there is only one digit, add a leading zero:
            if (month.Length == 1)
                month = "0" + month;

            // We require a two-digit day. If there is only one digit, add a leading zero:
            if (day.Length == 1)
                day = "0" + day;

            // We require a four-digit year. If there are only two digits, add 
            // two digits denoting the current century as leading numerals:
            if (year.Length == 2)
                year = "19" + year;

            // Put the date back together again with proper delimiters, and 
            text = day + "/" + month + "/" + year;
            return text;
        }
        
        public static DateTime? CreateDate(string text, string dateFormat = "dd-MM-yyyy")
        {
            //very hacky
            if (text.IndexOf('-') >= 4)
            {
                text = AdjustDateFormat(text);
                dateFormat = "dd/MM/yyyy";
            }

            if (text.Contains("/") && dateFormat.Contains("-"))
                dateFormat = dateFormat.Replace("-", "/");
            if (text.Contains(" 00:00:00"))
                text = text.Replace(" 00:00:00", "");

            DateTime d;
            DateTime? result = null;
            if (DateTime.TryParseExact(text, dateFormat,
                                           CultureInfo.InvariantCulture, 
                                           DateTimeStyles.None,
                                           out d))
            {
                result = d;
            }
            return result;
        }

        public static bool ValidateDate(string text, string dateFormat = "dd-MM-yyyy", string separator = null)
        {
            separator = Thread.CurrentThread.CurrentCulture.DateTimeFormat.DateSeparator;

            // Remove delimiters from the text contained in the control. 
            string dateContents = text.Replace(separator, "").Trim();

            // if no date was entered, we wil be left with an empty string or whitespace. Otherwise:
            if (!string.IsNullOrEmpty(dateContents) && dateContents != "")
            {
                // Split the original date into components:
                string[] dateSoFar = text.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);
                //check if the format is correct
                if(dateSoFar.Length != 3)
                    return false;
                //if correct split into parts
                string day = dateSoFar[0].Trim();
                string month = dateSoFar[1].Trim();
                string year = dateSoFar[2].Trim();

                // If the component values are of the proper length for mm/dd/yyyy formatting:
                if (month.Length == 2
                    && day.Length == 2
                    && year.Length == 4
                    && (year.StartsWith("19") || year.StartsWith("20")))
                {
                    // Check to see if the string resolves to a valid date:
                    DateTime d;
                    if (!DateTime.TryParseExact(text, "dd-MM-yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out d))
                    {
                        // The string did NOT resolve to a valid date:
                        return false;
                    }
                    else
                        // The string resolved to a valid date:
                        return true;
                }
                else
                {
                    // Components are not of the correct size, and automatic adjustment is unsuccessful:
                    return false;

                } // End if Components are correctly sized
            }
            else
                // The date string is empty or whitespace - no date is a valid return:
                return true;
        }
    }
}