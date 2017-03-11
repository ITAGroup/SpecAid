using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SpecAid.Base;
using SpecAid.Helper;

namespace SpecAid.SetTranslations
{
    public class SetTranslator
    {
        /// <summary>
        /// Gets the appropriate value for the cell
        /// </summary>
        public static object Translate(PropertyInfo info, object target, object newItem)
        {
            var translations = GetSetTranslations();

            foreach (var action in translations)
            {
                if (!action.UseWhen(info,target,newItem))
                    continue;

                return action.Do(info, target, newItem);
            }

            return newItem;
        }

        private static IEnumerable<ISetTranslation> GetSetTranslations()
        {
            if (_setActions != null)
                return _setActions;

            var specAidAssembly = Assembly.GetExecutingAssembly();

            var specAidTypes = specAidAssembly.GetTypes()
                .Where(typeof (ISetTranslation).IsAssignableFrom)
                .Where(x => !x.IsAbstract).ToList();

            var specAidTranlations =
                specAidTypes.Select(action => (ISetTranslation)Activator.CreateInstance(action)).OrderBy(t => t.ConsiderOrder);

            var testAssembly = AssemblyEntryFinderInUnitTests.Go();

            var testTypes = testAssembly.GetTypes()
                .Where(typeof(ISetTranslation).IsAssignableFrom)
                .Where(x => !x.IsAbstract).ToList();

            var testTranlations =
                testTypes.Select(action => (ISetTranslation)Activator.CreateInstance(action)).OrderBy(t => t.ConsiderOrder);

            _setActions = testTranlations.Union(specAidTranlations);

            return _setActions;
        }

        private static IEnumerable<ISetTranslation> _setActions;
    }
}
