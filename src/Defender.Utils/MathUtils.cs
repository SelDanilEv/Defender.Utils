using System;

namespace Defender.Utils
{
    public class MathUtils
    {
        public static double RoundUp(double number, int digits)
        {
            var factor = Convert.ToDouble(Math.Pow(10, digits));
            return Math.Ceiling(number * factor) / factor;
        }
    }
}
