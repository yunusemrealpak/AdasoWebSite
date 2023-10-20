using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Web.Script.Serialization;

namespace Helper
{
    public class DateTR
    {

        public string DayStr { get; set; }
        public string MonthStr { get; set; }
        public string DayNum { get; set; }
        public string MonthNum { get; set; }
        public string YearNum { get; set; }
        public string MinuteNum { get; set; }
        public string HourNum { get; set; }


        public DateTR()
        {

            DayStr = CultureInfo.GetCultureInfo("tr-TR").DateTimeFormat.DayNames[(int)DateTime.Now.DayOfWeek].ToString();
            MonthStr = CultureInfo.GetCultureInfo("tr-TR").DateTimeFormat.MonthNames[(int)DateTime.Now.Month].ToString();
            DayNum = DateTime.Now.ToLocalTime().Day.ToString("00.##");
            MonthNum = DateTime.Now.ToLocalTime().Month.ToString("00.##");
            YearNum = DateTime.Now.ToLocalTime().Year.ToString("00.##");
            MinuteNum = DateTime.Now.ToLocalTime().Minute.ToString("00.##");
            HourNum = DateTime.Now.ToLocalTime().Hour.ToString("00.##");

        }

    }

    public static class VariableConvertHelper
    {
        public static string getFullMonthName(int month)
        {
            return CultureInfo.CurrentCulture.
            DateTimeFormat.GetMonthName
            (month);
        }

        public static int ToInt(this object o)
        {
            try
            {
                return o is DBNull || o == null || string.IsNullOrEmpty(o.ToString()) ? 0 : Convert.ToInt32(o.ToString().Replace("_", ""));
            }
            catch
            {
                return 0;
            }
        }

        public static double ToDouble(this object o)
        {
            try
            {
                return o is DBNull || o == null || string.IsNullOrEmpty(o.ToString()) ? 0 : Convert.ToDouble(o);
            }
            catch
            {
                return 0;
            }
        }

        public static string ToDateTimeLocal(this object o)
        {
            try
            {
                return o is DBNull || o == null || string.IsNullOrEmpty(o.ToString()) ? o.ToDateTime().ToString("yyyy-MM-dd") : o.ToDateTime().ToString("yyyy-MM-dd HH:mm:ss").Replace(' ', 'T');
            }
            catch
            {
                return o.ToString();
            }
        }
        public static decimal ToDecimal(this object o)
        {
            try
            {
                return o is DBNull || o == null || string.IsNullOrEmpty(o.ToString()) ? 0 : Convert.ToDecimal(o);
            }
            catch
            {
                return 0;
            }
        }

        public static DateTime ToDateTime(this object o)
        {
            try
            {
                return o is DBNull || o == null || string.IsNullOrEmpty(o.ToString()) ? new DateTime(1900, 1, 1) : Convert.ToDateTime(o);
            }
            catch
            {
                return new DateTime(1900, 1, 1);
            }
        }

        public static DateTime ToDateTime(this object o, DateTime date)
        {
            try
            {
                return o is DBNull || o == null || string.IsNullOrEmpty(o.ToString()) ? date : Convert.ToDateTime(o);
            }
            catch
            {
                return date;
            }
        }


        public static DateTime ToDateTime(this object o, string time)
        {
            try
            {
                if (o is DBNull || o == null || string.IsNullOrEmpty(o.ToString()))
                {
                    return new DateTime(1900, 1, 1, 0, 0, 0);
                }
                else
                {
                    DateTime date = Convert.ToDateTime(o);
                    date = date.AddHours(time.Split(':')[0].ToDouble());
                    date = date.AddMinutes(time.Split(':')[1].ToDouble());
                    return Convert.ToDateTime(date);
                }
            }
            catch
            {
                return new DateTime(1900, 1, 1, 0, 0, 0);
            }
        }

        public static bool ToBool(this object o)
        {
            try
            {
                return o is DBNull || o == null || string.IsNullOrEmpty(o.ToString()) ? false : Convert.ToBoolean(o);
            }
            catch
            {
                return false;
            }
        }

        public static Guid ToGuid(this object o)
        {
            try
            {
                return o is DBNull || o == null ? Guid.Empty : Guid.Parse(o.ToString());
            }
            catch
            {
                return Guid.Empty;
            }
        }

        public static string ToMoney(this object o)
        {
            if (o == null) return "Yok.";

            if (double.TryParse(o.ToString().Replace(".", ","), out double d))
            {
                string result = "";
                result = d.ToString("C", CultureInfo.CreateSpecificCulture("tr-TR"));
                return result.Substring(0, result.Length - 5);
            }
            else
            {
                return o.ToString();
            }

        }

        public static string ToJson(this object o)
        {
            try
            {
                return JsonConvert.SerializeObject(o);
            }
            catch
            {
                return "";
            }
        }

        public static T ToJsonDeserialize<T>(this object o)
        {
            return (T)new JavaScriptSerializer().Deserialize<T>(o.ToString());
        }

        public static string ToFileSize(double value)
        {
            string[] suffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            for (int i = 0; i < suffixes.Length; i++)
            {
                if (value <= (Math.Pow(1024, i + 1)))
                {
                    return ThreeNonZeroDigits(value / Math.Pow(1024, i)) + " " + suffixes[i];
                }
            }

            return ThreeNonZeroDigits(value / Math.Pow(1024, suffixes.Length - 1)) +
                " " + suffixes[suffixes.Length - 1];
        }
        private static string ThreeNonZeroDigits(double value)
        {
            if (value >= 100)
            {
                // No digits after the decimal.
                return value.ToString("0,0");
            }
            else if (value >= 10)
            {
                // One digit after the decimal.
                return value.ToString("0.0");
            }
            else
            {
                // Two digits after the decimal.
                return value.ToString("0.00");
            }
        }
    }



}
