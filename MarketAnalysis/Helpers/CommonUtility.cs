using MarketAnalysis.Helpers;
using System;
using System.Linq;

public static class CommonUtility
{
    public static string RemoveNumericFormat(this string input)
    {
        var result = input
            .Replace(",", "")
            .Replace("%", "")
            .Replace("(", "")
            .Replace(")", "")
            .Trim();

        return result;
    }

    public static string TrimName(string name)
    {
        var temp = name.EmptyIfNull().CleanString();
        if (temp.IsNotNull())
        {
            var str = temp
                .Replace("%", "-")
                .Replace(".", "-")
                .Replace(":", "-")
                .Replace("~", "-")
                .Replace("/", "-")
                .Replace("!", "-")
                .Replace("@", "-")
                .Replace("#", "-")
                .Replace("$", "-")
                .Replace("^", "-")
                .Replace("&", "-")
                .Replace("*", "-")
                .Replace("(", "-")
                .Replace(")", "-")
                .Replace("'", "-")
                .Replace("+", "-")
                .Replace("=", "-")
                .Replace("[", "-")
                .Replace("]", "-")
                .Replace("{", "-")
                .Replace("}", "-")
                .Replace(",", "-")
                .Replace(";", "-")
                .Replace("`", "-")
                .Replace("<", "-")
                .Replace(">", "-")
                .Replace("|", "-")
                .Replace("/", "-")
                .Replace("\\", "-")
                .Replace("\"", "-")
                .Replace("-", " ");

            var arr = str.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            return arr.Join(" ");
        }
        else
            return null;
    }

    public static string SuggestUrl(this string url)
    {
        var temp = url.EmptyIfNull().CleanString();
        if (temp.IsNotNull())
        {
            var str = url
                .Replace("%", "-")
                .Replace(".", "-")
                .Replace(":", "-")
                .Replace("~", "-")
                .Replace("/", "-")
                .Replace("!", "-")
                .Replace("@", "-")
                .Replace("#", "-")
                .Replace("$", "-")
                .Replace("^", "-")
                .Replace("&", "-")
                .Replace("*", "-")
                .Replace("(", "-")
                .Replace(")", "-")
                .Replace("'", "-")
                .Replace("+", "-")
                .Replace("=", "-")
                .Replace("[", "-")
                .Replace("]", "-")
                .Replace("{", "-")
                .Replace("}", "-")
                .Replace(",", "-")
                .Replace(";", "-")
                .Replace("`", "-")
                .Replace("<", "-")
                .Replace(">", "-")
                .Replace("|", "-")
                .Replace("/", "-")
                .Replace("\\", "-")
                .Replace("\"", "-")
                .Replace("-", " ");

            var arr = str.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            return arr.Join("-");
        }
        else
            return null;
    }

    public static bool IsNotNull(this object obj)
    {
        return obj != null;
    }
}
