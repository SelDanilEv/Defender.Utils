using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DefenderUniversalLibrary
{
    public static class  RegulatExpressions_Lib
    {
        static Regex regex; 

        public static void SetExpression(string s)
        {
            regex = new Regex(s);
        }

        public static void SetRegex(Regex r)
        {
            regex = r;
        }

        public static MatchCollection GetResults(string str) =>
            regex.Matches(str);

        public static bool IsMatch(string str) =>
            regex.IsMatch(str);

        public static Match GetResult(string str) =>
            regex.Match(str);
    }
}
