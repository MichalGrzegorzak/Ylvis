using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commons.Html
{
    public abstract class HtmlHelper
    {
        public static string CutOffValueFromQuotas(string input, string lookFor, char quota)
        {
            string result = "";
            int begin = input.IndexOf(lookFor);
            if (begin == -1)
                return "";

            int firstQuota = input.IndexOf(quota, begin) + 1; //after quota
            int endQuota = input.IndexOf(quota, firstQuota);
            result = input.Substring(firstQuota, endQuota - firstQuota);
            return result;
        }

        public static string TextFrom(string input, bool lookingForEnd, params string[] match)
        {
            string result = input;
            int idx = -1;

            foreach (string s in match)
            {
                idx = input.IndexOf(s, idx + 1);
                if (idx == -1)
                    break;
            }

            idx = idx + match.Last().Length;
            if (!lookingForEnd)
            {
                result = result.Substring(idx, input.Length - idx);
            }
            else
            {
                result = result.Substring(0, idx);
            }

            return result;
        }
    }
}
