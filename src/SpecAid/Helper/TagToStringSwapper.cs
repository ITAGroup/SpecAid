using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using SpecAid.Extentions;

namespace SpecAid.Helper
{
    public static class TagToStringSwapper
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

                    var tag = textToReplace.TrimAlphaOmega();

                    try
                    {
                        var stuff = FieldAid.ObjectCreator<string>(tag);
                        innerCode = innerCode.Replace(textToReplace, stuff);
                        ididsomething = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Warning: " + ex.Message);
                    }
                }

                matches = regex.Match(innerCode);
            }

            return innerCode;
        }


    }
}
