using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using SpecAid.Base;
using SpecAid.Helper;

namespace SpecAid.Translations
{
    public class Translator
    {
        /// <summary>
        /// Gets the appropriate value for the cell
        /// </summary>
        /// <param name="tableValue"></param>
        /// <returns></returns>
        public static object Translate(PropertyInfo info, string tableValue)
        {
            var translations = getTranslations();

            foreach (var action in translations)
            {
                if (!(action.UseWhen(info,tableValue)))
                    continue;

                return action.Do(info, tableValue);
            }

            return tableValue;
        }

        /// <summary>
        /// Do all of the cell actions
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<ITranslation> getTranslations()
        {
            if (_cellActions == null)
            {
                var specAidAssembly = Assembly.GetExecutingAssembly();

                var specAidTypes = specAidAssembly.GetTypes()
                    .Where(typeof (ITranslation).IsAssignableFrom)
                    .Where(x => !x.IsAbstract).ToList();

                var specAidTranlations =
                    specAidTypes.Select(action => (ITranslation)Activator.CreateInstance(action)).OrderBy(t => t.considerOrder);


                var testAssembly = AssemblyEntryFinderInUnitTests.Go();

                var testTypes = testAssembly.GetTypes()
                    .Where(typeof(ITranslation).IsAssignableFrom)
                    .Where(x => !x.IsAbstract).ToList();

                var testTranlations =
                    testTypes.Select(action => (ITranslation)Activator.CreateInstance(action)).OrderBy(t => t.considerOrder);

                _cellActions = testTranlations.Union(specAidTranlations);
            }
            return _cellActions;
        }

        private static IEnumerable<ITranslation> _cellActions;
    }
}
