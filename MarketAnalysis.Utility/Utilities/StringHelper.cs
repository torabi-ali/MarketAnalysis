using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace MarketAnalysis.Utility
{
    public static class StringHelper
    {
        public static bool HasValue(this string value, bool ignoreWhiteSpace = false)
        {
            return !(ignoreWhiteSpace ? string.IsNullOrWhiteSpace(value) : string.IsNullOrEmpty(value));
        }

        public static string GetNumbers(string input)
        {
            return new string(input.Where(c => char.IsDigit(c)).ToArray());
        }

        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }

        public static string GetFirstWord(this string str)
        {
            var arr = str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return arr.Length >= 1 ? arr[0] : "";
        }

        public static string NullIfEmpty(this string str)
        {
            return (str == "" ? null : str);
        }

        public static string EmptyIfNull(this string str)
        {
            return (str == null ? "" : str);
        }

        public static string Summary(this string str, int lenght, bool hasDot = false)
        {
            if (str.Length < lenght) return str;
            else return str.Substring(0, lenght - (hasDot ? 4 : 0)) + (hasDot ? " ..." : "");
        }

        /// <summary>
        /// Checks string object's value to array of string values
        /// </summary>       
        /// <param name="stringValues">Array of string values to compare</param>
        /// <returns>Return true if any string value matches</returns>
        public static bool In(this string str, params string[] stringValues)
        {
            foreach (var item in stringValues)
                if (string.Compare(str, item) == 0)
                    return true;

            return false;
        }

        /// <summary>
        /// Returns characters from right of specified length
        /// </summary>
        /// <param name="str">String value</param>
        /// <param name="length">Max number of charaters to return</param>
        /// <returns>Returns string from right</returns>
        public static string Right(this string str, int length)
        {
            return str != null && str.Length > length ? str.Substring(str.Length - length) : str;
        }

        /// <summary>
        /// Returns characters from left of specified length
        /// </summary>
        /// <param name="str">String value</param>
        /// <param name="length">Max number of charaters to return</param>
        /// <returns>Returns string from left</returns>
        public static string Left(this string str, int length)
        {
            return str != null && str.Length > length ? str.Substring(0, length) : str;
        }

        public static string RemoveLeft(this string str, int length)
        {
            return str.Remove(0, length);
        }

        public static string RemoveRight(this string str, int length)
        {
            return str.Remove(str.Length - length);
        }

        /// <summary>
        ///  Replaces the format item in a specified System.String with the text equivalent
        ///  of the value of a specified System.Object instance.
        /// </summary>
        /// <param name="str">A composite format string</param>
        /// <param name="args">An System.Object array containing zero or more objects to format.</param>
        /// <returns>A copy of format in which the format items have been replaced by the System.String
        /// equivalent of the corresponding instances of System.Object in args.</returns>
        public static string Format(this string str, params object[] args)
        {
            return string.Format(str, args);
        }

        public static string Join(this IEnumerable<string> arr, string separator)
        {
            return string.Join(separator, arr);
        }

        public static string DeleteChars(this string str, params char[] chars)
        {
            return new string(str.Where(ch => !chars.Contains(ch)).ToArray());
        }

        public static string DeleteStrs(this string str, params string[] strs)
        {
            foreach (var item in strs)
                str = str.Replace(item, "");
            return str;
        }

        public static string ToLowerFirst(this string str)
        {
            char[] a = str.ToCharArray();
            a[0] = char.ToLower(a[0]);
            return new string(a);
        }

        public static string ToUpperFirst(this string str)
        {
            char[] a = str.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

        /// <summary>
        /// Returns the first string with a non-empty non-null value.
        /// </summary>
        public static string Or(this string str, string alternative)
        {
            return (!string.IsNullOrEmpty(str)) ? str : alternative;
        }

        public static string En2Fa(this string str)
        {
            return
                str.Replace("0", "۰")
                    .Replace("1", "۱")
                    .Replace("2", "۲")
                    .Replace("3", "۳")
                    .Replace("4", "۴")
                    .Replace("5", "۵")
                    .Replace("6", "۶")
                    .Replace("7", "۷")
                    .Replace("8", "۸")
                    .Replace("9", "۹");
        }

        public static string Fa2En(this string str)
        {
            return str
                    .Replace("۰", "0")
                    .Replace("۱", "1")
                    .Replace("۲", "2")
                    .Replace("۳", "3")
                    .Replace("۴", "4")
                    .Replace("۵", "5")
                    .Replace("۶", "6")
                    .Replace("۷", "7")
                    .Replace("۸", "8")
                    .Replace("۹", "9")

                    .Replace("٠", "0")
                    .Replace("١", "1")
                    .Replace("٢", "2")
                    .Replace("٣", "3")
                    .Replace("٤", "4")
                    .Replace("٥", "5")
                    .Replace("٦", "6")
                    .Replace("٧", "7")
                    .Replace("٨", "8")
                    .Replace("٩", "9");
        }

        public static string FixPersianChars(this string str)
        {
            return str.Replace("ﮎ", "ک").Replace("ﮏ", "ک").Replace("ﮐ", "ک").Replace("ﮑ", "ک").Replace("ك", "ک").Replace("ي", "ی").Replace(" ", " ").Replace("‌", " ");//.Replace("ئ", "ی");
        }

        public static string CleanString(this string str)
        {
            return str.Trim().FixPersianChars().Fa2En().NullIfEmpty();
        }

        public static string RemoveLetters(this string text)
        {
            return Regex.Replace(text, "[^0-9.]", "");
        }

        public static string RemoveStr(this string text, params string[] strs)
        {
            strs.ForEach(p => text = text.Replace(p, ""));
            return text;
        }
    }
}