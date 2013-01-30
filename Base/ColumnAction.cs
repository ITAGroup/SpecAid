using System;

namespace SpecAid.Base
{
    public abstract class ColumnAction : IColumnAction
    {
        /// <summary>
        /// This is here to help inforce there is one of these on each action
        /// </summary>
        /// <param name="targetType"></param>
        /// <param name="columnName"></param>
        protected ColumnAction(Type targetType, string columnName)
        {
            TargetType = targetType;
            ColumnName = columnName;
        }

        public Type TargetType { get; set; }
        public string ColumnName { get; set; }
        public abstract bool UseWhen();
        public abstract int considerOrder { get; }

    }
}
