namespace Essa.Framework.Util.Extensions
{
    public static class DecimalExtensions
    {

        public static decimal IfNegativeToPositive(this decimal value)
        {
            return value < 0 ? value * -1 : value;
        }


        /// <summary>
        /// IfGreaterLessOrZero
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="seMaior"></param>
        /// <param name="seMenor"></param>
        /// <param name="seZero"></param>
        /// <returns></returns>
        public static string MaiorMenorOuZero(this decimal valor, string seMaior, string seMenor, string seZero)
        {
            switch (valor.CompareTo(0))
            {
                case -1:
                    return seMenor;
                case 0:
                    return seZero;
                default:
                    return seMaior;
            }
        }

    }
}
