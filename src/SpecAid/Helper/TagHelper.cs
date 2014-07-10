using SpecAid.Base;

namespace SpecAid.Helper
{
    public static class TagHelper
    {
        public static bool IsBracketTag(string s)
        {
            return (s.StartsWith("<<") && s.EndsWith(">>") && s.Length >= 5);
        }

        public static bool IsHashTag(string s)
        {
            if (!SpecAidSettings.UseHashTag)
                return false;

            if (s.Contains("."))
                return false;

            return (s.StartsWith("#") && s.Length >= 2);
        }

        public static bool IsTag(string s)
        {
            if (IsBracketTag(s))
                return true;

            if (IsHashTag(s))
               return true;

            return false;
        }

        public static string Normalizer(string s)
        {
            if (!IsTag(s))
                return s;

            if (SpecAidSettings.UseHashTag)
                return NormalizeToHashTag(s);

            return s;
        }

        private static string NormalizeToHashTag(string s)
        {
            if (IsHashTag(s))
                return s;

            if (IsBracketTag(s))
            {
                var innerTag = s.Substring(2, s.Length - 4);
                var noperiods = innerTag.Replace(".", "");
                return "#" + noperiods;
            }

            return s;
        }
    }
}
