using System;

namespace Ylvis.Utils.Extensions
{
    public static class MathExtensions
    {
        public static int Round(this double input, int decimalPlaces = 2)
        {
            return (int)Math.Round(input, decimalPlaces);
        }

        public static string ElapsedToString(this TimeSpan elapsed)
        {
            var seconds = elapsed.TotalSeconds;
            if (seconds > 100)
                return elapsed.TotalMinutes.Round() + " min";
            else if (seconds > 10)
                return elapsed.TotalSeconds.Round() + " sec";
            else
                return elapsed.TotalMilliseconds.Round() + " milisec";
        }
    }
}