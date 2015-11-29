using System;
using System.Diagnostics;

namespace Aegon.Helpers
{
    public static class AutomationHelper
    {
        public static void Wait(TimeSpan timeout)
        {
            System.Threading.Thread.Sleep(timeout);
        }

        public static void WaitMillieconds(int milliseconds)
        {
            Wait(TimeSpan.FromMilliseconds(milliseconds));
        }

        public static void WaitSeconds(int seconds)
        {
            Wait(TimeSpan.FromSeconds(seconds));
        }

        public static bool Wait(Func<bool> callback, TimeSpan timeout, TimeSpan? pollPeriod = null)
        {
            if (!pollPeriod.HasValue)
            {
                pollPeriod = TimeSpan.FromSeconds(1);
            }
            var watch = Stopwatch.StartNew();
            while (watch.Elapsed < timeout)
            {
                Wait(pollPeriod.Value);
                if (callback())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
