using System;

namespace Helper
{
    public static class VariableConvertHelperBase
    {


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
    }
}