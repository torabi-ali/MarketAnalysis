using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MarketAnalysis.Utility
{
    public static class ConvertorHelper
    {
        public static string ConvertToString(IEnumerable<ValueType> value)
        {
            return string.Join("-", value);
        }
        public static string ConvertToString(DateTime value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }
        public static string ConvertToString(TimeSpan value, bool includeNow = false)
        {
            return value.ToString("c", CultureInfo.InvariantCulture);
        }

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

        public static string ToPrice(this object dec)
        {
            var Src = dec.ToString();
            Src = Src.Replace(".0000", "");
            if (!Src.Contains("."))
            {
                Src = Src + ".00";
            }
            var price = Src.Split('.');

            if (price[1].Length >= 2)
            {
                price[1] = price[1].Substring(0, 2);
                price[1] = price[1].Replace("00", "");
            }

            string Temp = null;

            var i = 0;

            if ((price[0].Length % 3) >= 1)
            {
                Temp = price[0].Substring(0, (price[0].Length % 3));
                for (i = 0; i <= (price[0].Length / 3) - 1; i++)
                {
                    Temp += "," + price[0].Substring((price[0].Length % 3) + (i * 3), 3);
                }
            }
            else
            {
                for (i = 0; i <= (price[0].Length / 3) - 1; i++)
                {
                    Temp += price[0].Substring((price[0].Length % 3) + (i * 3), 3) + ",";
                }
                Temp = Temp.Substring(0, Temp.Length - 1);
                // Temp = price(0)
                //If price(1).Length > 0 Then
                //    Return price(0) + "." + price(1)
                //End If
            }
            if (price[1].Length > 0)
            {
                return Temp + "." + price[1];
            }
            return Temp;
        }
        public static string ToPriceString(this object obj)
        {
            return obj.ToString().Trim('0').Trim('.');
        }

        public static string ConvertUrlsToLinks(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            string regex = @"((www\.|(http|https|ftp|news|file)+\:\/\/)[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])";

            var html = new Regex(regex, RegexOptions.IgnoreCase).Replace(str, "<a href=\"$1\" target=\"&#95;blank\">$1</a><br />").Replace("href=\"www", "href=\"http://www");

            return html;
        }
    }
}