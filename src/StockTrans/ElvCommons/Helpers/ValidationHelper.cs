using System.Text.RegularExpressions;

namespace Helpers
{
    ///<summary>Class checks if email is correct
    ///</summary>
    public abstract class ValidationHelper
    {
        /// <summary>
        /// Match email address to regex
        /// </summary>
        /// <param name="email">address</param>
        /// <returns>true if valid</returns>
        public static bool IsEmailValid(string email)
        {
            bool result = true;
            if (!string.IsNullOrEmpty(email))
            {
                //Regex reg = new Regex(@".*@.{2,}\..{2,}", RegexOptions.Compiled); //mail address
                string wellFormedEmail =
                    @"^(([^<>;()[\]\\.,;:@""\s]+(\.[^<>()[\]\\.,;:@""\s]+)*)|("".+""))@((\[([0-9]{1,3}\.){3}[0-9]{1,3}\])|(([a-zA-Z0-9]+[\.\-]?)*[a-zA-Z0-9]{1}\.(([a-zA-Z]{2,3})|(aero|coop|info|museum|name))))$";
                Regex reg = new Regex(wellFormedEmail, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                result = reg.IsMatch(email);
            }
            return result;
        } 
    }
}
