using System;
using System.Globalization;
using System.Linq;

namespace Helper
{
    public static class StringHelper
    {
        public static string StringLenghtChange(this string o, int lenght)
        {
            if (o.Length > lenght)
            {
                return o.Substring(0, lenght) + "...";
            }
            else
            {
                return o;
            }
        }

        public static string ToTitleCase(this string Text) { return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Text); }

        public static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }
    }
}