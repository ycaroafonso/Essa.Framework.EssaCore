using Essa.Framework.Util.Extensions;
using System;
using System.Text.RegularExpressions;

namespace Essa.Framework.Util.Util
{
    public static class Formatar
    {
        [Obsolete("Utilizar: UtilCPF.Formata(valor)")]
        public static string Cpf(this string valor)
        {
            return UtilCPF.Formatar(valor);
        }

        [Obsolete]
        public static string Cnpj(this string valor)
        {
            if (string.IsNullOrEmpty(valor)) return valor;
            return string.Format(@"{0:00\.000\.000\/0000\-00}", Convert.ToInt64(valor));
        }

        [Obsolete]
        public static string CpfCnpj(this string valor)
        {
            if (string.IsNullOrEmpty(valor))
                return string.Empty;

            if (valor.Length == 11)
                return valor.Cpf();
            else
                return valor.Cnpj();
        }

    }

    public static class Validar
    {

        public static bool ValidarCPF(this string cpf)
        {
            return UtilCPF.Validar(cpf);
        }

        public static bool ValidarEmail(this string email)
        {
            try
            {
                return !string.IsNullOrEmpty(email) && Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
