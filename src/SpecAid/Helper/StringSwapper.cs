using System;
using System.Text.RegularExpressions;
using SpecAid.Extentions;

namespace SpecAid.Helper
{
    public static class StringSwapper
    {
        public static string Swap(string code)
        {
            var regex = new Regex("{[^{}]*}");
            var innerCode = code;

            var matches = regex.Match(innerCode);
            var stopTheMadness = 5;
            var ididsomething = true;

            while (matches.Success && stopTheMadness > 0 && ididsomething)
            {
                stopTheMadness--;
                ididsomething = false;

                foreach (Group group in matches.Groups)
                {
                    var textToReplace = group.Value;

                    var textToSwap = textToReplace.TrimAlphaOmega();

                    try
                    {
                        var replaceResult = FieldAid.ObjectCreator<string>(textToSwap);

                        // we didn't actually do anything.
                        // don't replace the tag.
                        if (textToSwap == replaceResult)
                            continue;

                        innerCode = innerCode.Replace(textToReplace, replaceResult);
                        ididsomething = true;
                    }
                    // ReSharper disable once EmptyGeneralCatchClause
                    // Test might be checking for output containing '{' and '}' don't break or crash.
                    // Maybe, consider logging result.
                    catch (Exception)
                    { }
                }

                matches = regex.Match(innerCode);
            }

            return innerCode;
        }
    }
}
