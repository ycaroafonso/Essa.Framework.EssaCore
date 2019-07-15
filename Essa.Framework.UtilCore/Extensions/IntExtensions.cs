using System;

namespace Essa.Framework.UtilCore.Extensions
{
    public static class IntExtensions
    {
        /// <summary>
        /// int anoMes = 201501.AddMonths(1); // Result: 201502
        /// int anoMes = 201512.AddMonths(1); // Result: 201601
        /// </summary>
        /// <param name="input"></param>
        /// <param name="months"></param>
        /// <returns></returns>
        public static int AddMonths(this int input, int months)
        {
            int ano = input.ToString().Substring(0, 4).ToInt32();
            int mes = input.ToString().Substring(4).ToInt32();

            if (months >= 0)
                for (int i = 0; i < months; i++)
                {
                    mes += 1;
                    if (mes == 13)
                    {
                        ano += 1;
                        mes = 1;
                    }
                }
            else
                for (int i = 0; i < months * -1; i++)
                {
                    mes -= 1;
                    if (mes == 0)
                    {
                        ano -= 1;
                        mes = 12;
                    }
                }
            return Convert.ToInt32(string.Format("{0}{1:00}", ano, mes));
        }

        public static T ToEnum<T>(this int value)
        {
            return (T)Enum.ToObject(typeof(T), value);
        }

        public static int IfZero(this int value, int ret)
        {
            return value == 0 ? ret : value;
        }

        public static int? IfZeroThenNull(this int value)
        {
            return value == 0 ? (int?)null : value;
        }



        public static string FormataAnoMes(this int value)
        {
            return value.ToString().Substring(4, 2) + "/" + value.ToString().Substring(0, 4);
        }



        public static string ToMesExtenso(this int mes)
        {
            return Geral.Meses()[mes - 1];
        }

    }
}
