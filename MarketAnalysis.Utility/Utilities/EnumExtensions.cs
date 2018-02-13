using System;
using System.Linq;

namespace MarketAnalysis.Utility
{
    public static class EnumExtensions
    {
        //Use (Enum)value instead of this
        public static T ToEnum<T>(this byte value)
        {
            return (from T e in Enum.GetValues(typeof(T)) where (e as Enum).ToByte() == value select e).SingleOrDefault();
        }

        //Use (Enum)value instead of this
        public static T ToEnum<T>(this int value)
        {
            return (from T e in Enum.GetValues(typeof(T)) where (e as Enum).ToInt() == value select e).SingleOrDefault();
        }
    }
}
