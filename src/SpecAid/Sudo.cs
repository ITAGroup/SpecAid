using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace SpecAid
{
    public class SudoProp<TObject,TProperty>
    {
        private readonly TObject _item;
        private readonly PropertyInfo _property;

        public SudoProp(TObject item, PropertyInfo property)
        {
            _item = item;
            _property = property;
        }

        public TProperty Value
        {
            get
            {
                return (TProperty)_property.GetValue(_item,null);
            }
            set
            {
                _property.SetValue(_item, value, null);
            }
        }
    }

    public static class Sudo
    {
        public static SudoProp<TObject, TProp> Prop<TObject, TProp>(TObject item, Expression<Func<TObject, TProp>> property)
        {
            var propertyInfo = GetPropertyIndo(property);

            var sudoProperty = new SudoProp<TObject, TProp>(item, propertyInfo);
            return sudoProperty;
        }

        private static PropertyInfo GetPropertyIndo<TObject, TProp>(Expression<Func<TObject, TProp>> selector)
        {
            Expression body = selector;
            if (body is LambdaExpression)
                body = ((LambdaExpression)body).Body;

            switch (body.NodeType)
            {
                case ExpressionType.MemberAccess:
                    return (PropertyInfo)((MemberExpression)body).Member;
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
