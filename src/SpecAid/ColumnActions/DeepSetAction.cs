using System;
using System.Linq;
using System.Reflection;
using SpecAid.Base;
using SpecAid.Helper;
using SpecAid.Extentions;

namespace SpecAid.ColumnActions
{
    //Action for setting the value in the object
    public class DeepSetAction : ColumnAction, ICreatorColumnAction
    {
        private ICreatorColumnAction _deepAction;

        public DeepSetAction(Type targetType, string columnName)
            : base(targetType, columnName)
        {
        }

        private PropertyInfo Info { get; set; }

        public void GoGoCreateColumnAction(object target, string tableValue)
        {
            if (tableValue == ConstantStrings.IgnoreCell)
                return;

            if (_deepAction != null)
            {
                _deepAction.GoGoCreateColumnAction(Info.GetValue(target, null), tableValue);
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

            _deepAction = ColumnActionFactory.GetAction<ICreatorColumnAction>(Info.PropertyType, nextColumnName);

            if (_deepAction == null)
            {
                return false;
            }

            return _deepAction.UseWhen();
        }

        public override int considerOrder
        {
            get { return ActionOrder.DeepSet.ToInt32(); }
        }
    }
}
