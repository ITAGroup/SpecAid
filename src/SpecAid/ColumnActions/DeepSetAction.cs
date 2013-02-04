using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using SpecAid.Base;
using SpecAid.Translations;
using SpecAid.Helper;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpecAid.ColumnActions
{
    //Action for setting the value in the object
    public class DeepSetAction : ColumnAction, ICreatorColumnAction
    {
        private ICreatorColumnAction deepAction;

        public DeepSetAction(Type targetType, string columnName)
            : base(targetType, columnName)
        {
        }

        private PropertyInfo Info { get; set; }

        public void GoGoCreateColumnAction(object target, string tableValue)
        {
            if (tableValue == ConstantStrings.IgnoreCell)
                return;

            if (deepAction != null)
            {
                deepAction.GoGoCreateColumnAction(Info.GetValue(target, null), tableValue);
            }
        }

        public override bool UseWhen()
        {
            // do deep property binding
            if (!(ColumnName.Contains('.')))
            {
                return false;
            }

            var propertyNames = ColumnName.Split('.');

            if (propertyNames.Count() <= 1)
            {
                throw new Exception(string.Format("Can not find any property represented by deep-binding syntax: \"{0}\"", ColumnName));
            }

            Info = PropertyInfoHelper.GetCaseInsensitivePropertyInfo(TargetType, propertyNames[0]);

            var nextColumnName = string.Join(".", propertyNames.Skip(1).ToList());

            deepAction = ColumnActionFactory.GetAction<ICreatorColumnAction>(Info.PropertyType, nextColumnName);

            if (deepAction == null)
            {
                return false;
            }

            return deepAction.UseWhen();
        }

        public override int considerOrder
        {
            get { return 9; }
        }

    }
}
