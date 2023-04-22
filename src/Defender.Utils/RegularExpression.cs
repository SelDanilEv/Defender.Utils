using System.Text.RegularExpressions;

namespace Defender.Utils
{
    public class RegularExpression
    {
        private Regex regex { get; set; }

        public void SetExpression(string s)
        {
            regex = new Regex(s);
        }

        public void SetRegex(Regex r)
        {
            regex = r;
        }

        public MatchCollection GetMatches(string str) =>
            regex.Matches(str);

        public bool IsMatch(string str) =>
            regex.IsMatch(str);

        public Match GetMatch(string str) =>
            regex.Match(str);
    }
}
