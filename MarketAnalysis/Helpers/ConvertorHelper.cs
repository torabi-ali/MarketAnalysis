using System;
using System.Collections.Generic;
using System.Text;

namespace MarketAnalysis.Helpers
{
    public static class ConvertorHelper
    {
        public static int TryToInt(this object obj)
        {
            var result = 0;
            try
            {
                result = Convert.ToInt32(obj);
            }
            catch
            {
            }
            return result;
        }

        public static decimal TryToDecimal(this object obj)
        {
            var result = 0M;
            try
            {
                result = Convert.ToDecimal(obj);
            }
            catch
            {
            }
            return result;
        }

        public static object ToDBNull(this object obj)
        {
            return DBNull.Value.Equals(obj) ? null : obj;
        }

        public static byte ToByte(this object obj)
        {
            return Convert.ToByte(obj);
        }

        public static bool ToBoolean(this object obj)
        {
            return Convert.ToBoolean(obj);
        }

        public static int BooleanToInt(this Boolean obj)
        {
            return obj == true ? 1 : 0;
        }

        public static decimal ToDecimal(this object obj)
        {
            return Convert.ToDecimal(obj);
        }

        public static int ToInt(this object obj)
        {
            return Convert.ToInt32(obj);
        }

        public static int? ToNullableInt(this object obj)
        {
            int? result = null;
            if (obj != null && obj.ToString() != "")
                result = Convert.ToInt32(obj);
            return result;
        }

        public static T CastTo<T>(this object obj)
        {
            return ((T)obj);
        }

        public static T ConvertTo<T>(this object obj)
        {
            return Convert.ChangeType(obj, typeof(T)).CastTo<T>();
        }
        public static object ConvertTo(this object obj, Type type)
        {
            return Convert.ChangeType(obj, type);
        }

        public static char ToASCIIchar(this int code)
        {
            return Convert.ToChar(code);
        }

        public static int ToASCIIcode(this char ch)
        {
            return Convert.ToInt32(ch);
        }

        public static string ToCSV<T>(this IEnumerable<T> instance)
        {
            StringBuilder csv;

            if (instance != null)
            {
                csv = new StringBuilder();
                instance.ForEach(v => csv.AppendFormat("{0},", v));
                return csv.ToString(0, csv.Length - 1);
            }
            return null;
        }

        public static string ToCSV<T>(this IEnumerable<T> instance, char separator)
        {
            StringBuilder csv;

            if (instance != null)
            {
                csv = new StringBuilder();
                instance.ForEach(value => csv.AppendFormat("{0}{1}", value, separator));
                return csv.ToString(0, csv.Length - 1);
            }
            return null;
        }

        public static string ToText(this int digit)
        {
            var txt = digit.ToString();

            var length = txt.Length;

            var a1 = new string[10] { "-", "یک", "دو", "سه", "چهار", "پنح", "شش", "هفت", "هشت", "نه" };

            var a2 = new string[10] { "ده", "یازده", "دوازده", "سیزده", "چهارده", "پانزده", "شانزده", "هفده", "هجده", "نوزده" };

            var a3 = new string[10] { "-", "ده", "بیست", "سی", "چهل", "پنجاه", "شصت", "هفتاد", "هشتاد", "نود" };

            var a4 = new string[10] { "-", "یک صد", "دویست", "سیصد", "چهارصد", "پانصد", "ششصد", "هفصد", "هشصد", "نهصد" };

            var result = "";

            var isDahegan = false;

            for (var i = 0; i < length; i++)
            {
                var character = txt[i].ToString();

                switch (length - i)
                {
                    case 7: //میلیون
                        if (character != "0")
                        {
                            result += a1[Convert.ToInt32(character)] + " میلیون و ";
                        }
                        else
                        {
                            result = result.TrimEnd('و', ' ');
                        }
                        break;
                    case 6: //صدهزار
                        if (character != "0")
                        {
                            result += a4[Convert.ToInt32(character)] + " و ";
                        }
                        else
                        {
                            result = result.TrimEnd('و', ' ');
                        }
                        break;
                    case 5: //ده هزار
                        if (character == "1")
                        {
                            isDahegan = true;
                        }
                        else if (character != "0")
                        {
                            result += a3[Convert.ToInt32(character)] + " و ";
                        }
                        break;
                    case 4: //هزار
                        if (isDahegan)
                        {
                            result += a2[Convert.ToInt32(character)] + " هزار و ";
                            isDahegan = false;
                        }
                        else
                        {
                            if (character != "0")
                            {
                                result += a1[Convert.ToInt32(character)] + " هزار و ";
                            }
                            else
                            {
                                result = result.TrimEnd('و', ' ');
                            }
                        }
                        break;
                    case 3: //صد
                        if (character != "0")
                        {
                            result += a4[Convert.ToInt32(character)] + " و ";
                        }
                        break;
                    case 2: //ده
                        if (character == "1")
                        {
                            isDahegan = true;
                        }
                        else if (character != "0")
                        {
                            result += a3[Convert.ToInt32(character)] + " و ";
                        }
                        break;
                    case 1: //یک
                        if (isDahegan)
                        {
                            result += a2[Convert.ToInt32(character)];
                            isDahegan = false;
                        }
                        else
                        {
                            if (character != "0") result += a1[Convert.ToInt32(character)];
                            else result = result.TrimEnd('و', ' ');
                        }
                        break;
                }
            }
            return result;
        }
    }
}