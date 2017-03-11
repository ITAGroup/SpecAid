using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SpecAid.Base;

namespace SpecAid.Helper
{
    public static class InstantProperty
    {
        public static PropertyInfo FromType(Type type)
        {
            Type customInstanceType = typeof(ObjectField<>).MakeGenericType(type);
            var instance = Activator.CreateInstance(customInstanceType);
            var propertyInfo = instance.GetType().GetProperty("field");

            return propertyInfo;
        }
    }
}
