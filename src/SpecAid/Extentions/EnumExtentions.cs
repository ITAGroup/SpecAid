using System;

namespace SpecAid.Extentions
{
    public static class EnumExtentions
    {
        public static int ToInt32(this Enum enumValue)
        {
            return Convert.ToInt32(enumValue);
        }
    }
}
