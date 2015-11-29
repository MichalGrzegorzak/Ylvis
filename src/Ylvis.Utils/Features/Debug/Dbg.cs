using System.Diagnostics;
using Ylvis.Utils.Extensions;

namespace Ylvis.Utils.Features.Debug
{
    public abstract class Dbg
    {
        public static void BreakOnNull(string target)
        {
            if (!Debugger.IsAttached)
                return;

            if(string.IsNullOrEmpty(target))
                Debugger.Break();

        }
        public static void BreakOnMatch(string target, params string[] matchAny)
        {
            if (!Debugger.IsAttached)
                return;

            if (target.ContainsAnyOf(matchAny))
                Debugger.Break();
        }
    }
}
