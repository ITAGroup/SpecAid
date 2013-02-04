using System;
using System.Linq;
using System.Reflection;
using SpecAid.Translations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecAid.Base;
using SpecAid.Helper;

namespace SpecAid.ColumnActions
{
    public class DeepCompareAction : ColumnAction, IComparerColumnAction
    {
        private PropertyInfo Info { get; set; }
        private IComparerColumnAction deepAction;

        public DeepCompareAction(Type targetType, string columnName)
            : base(targetType, columnName)
        {
        }

        public CompareColumnResult GoGoCompareColumnAction(object target, string tableValue)
        {
            if (tableValue == ConstantStrings.IgnoreCell)
                return new CompareColumnResult();

            if (deepAction != null)
            {
                return deepAction.GoGoCompareColumnAction(Info.GetValue(target, null), tableValue);
            }
            return new CompareColumnResult();
        }

        public CompareColumnResult GoGoCompareColumnAction(string tableValue)
        {
            if (tableValue == ConstantStrings.IgnoreCell)
                return new CompareColumnResult();

            if (deepAction != null)
            {
                return deepAction.GoGoCompareColumnAction(tableValue);
            }
            return new CompareColumnResult();
        }

        public CompareColumnResult GoGoCompareColumnAction(object target)
        {
            if (deepAction != null)
            {
                return deepAction.GoGoCompareColumnAction(Info.GetValue(target, null));
            }
            return new CompareColumnResult();
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

            deepAction = ColumnActionFactory.GetAction<IComparerColumnAction>(Info.PropertyType, nextColumnName);

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
