﻿using System;
using System.Reflection;
using SpecAid.Base;
using SpecAid.Extentions;
using SpecAid.Helper;

namespace SpecAid.Translations
{
    public class EnumTranslation : ITranslation
    {
        public object Do(PropertyInfo info, string tableValue)
        {
            return Enum.Parse(info.PropertyType, tableValue, true);
        }

        public bool UseWhen(PropertyInfo info, string tableValue)
        {
            return info.PropertyType.IsEnum;
        }

        public int ConsiderOrder
        {
            get { return TranslationOrder.Enum.ToInt32(); }
        }

    }
}
