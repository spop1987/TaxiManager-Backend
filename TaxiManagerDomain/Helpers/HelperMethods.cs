using System.Globalization;

namespace TaxiManagerDomain.Helpers
{
    public static class HelperMethods
    {
        public static int ToInt(this string value)
        {
            if(!string.IsNullOrEmpty(value))
                return int.Parse(value);
            
            return 0;
        } 

        public static string Stringify(this long value)
        {
            if(value > 0)
                return value.ToString();
            
            return string.Empty;
        }

        public static DateTime ToDateTime(this string value)
        {
            if(string.IsNullOrEmpty(value)) return DateTime.MinValue;

            return DateTime.ParseExact(value, "yyyy/MM/dd", CultureInfo.InvariantCulture);
        }
    }
}