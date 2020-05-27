using System;
using System.Collections.Generic;
using System.Text;

namespace DefenderUniversalLibrary
{
    public static class Math_Lib
    {
        public static double RoundUp(double number, int digits)
        {
            var factor = Convert.ToDouble(Math.Pow(10, digits));
            return Math.Ceiling(number * factor) / factor;
        }
    }
}
