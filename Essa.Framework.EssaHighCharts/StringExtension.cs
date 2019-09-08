namespace Highcharts.MVC
{
    public static class StringExtension
    {
        public static string FormatWith(this string currentString, params object[] args)
        {
            return string.Format(currentString, args);
        }
    }
}
