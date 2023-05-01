using Essa.Framework.Util.Extensions;
using System;
using System.Text.RegularExpressions;

namespace Essa.Framework.Util.Util
{
    public static class Formatar
    {
        [Obsolete]
        public static string Cpf(this string valor)
        {
            if (string.IsNullOrEmpty(valor)) return valor;
            return string.Format(@"{0:000\.000\.000\-00}", Convert.ToInt64(valor));
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
            if (string.IsNullOrEmpty(cpf))
                return false;

            var regEx = new Regex(@"^\d{11}|((\d{3}.){2}\d{3}-\d{2})$", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            if (!regEx.IsMatch(cpf))
                return false;

            var cpfSemFormatacao = cpf.RemoveMascara();

            if (cpfSemFormatacao.Equals("00000000000") || cpfSemFormatacao.Length != 11)
                return false;

            switch (cpfSemFormatacao)
            {
                case "00000000000":
                case "11111111111":
                case "22222222222":
                case "33333333333":
                case "44444444444":
                case "55555555555":
                case "66666666666":
                case "77777777777":
                case "88888888888":
                case "99999999999": //Removido pois este cpf é o ADMINISTRADOR do sistema, ou seja, é um cpf VÁLIDO.
                    return false;
            }

            var total = 0;
            total += int.Parse(cpfSemFormatacao[..1]) * 10;
            total += int.Parse(cpfSemFormatacao.Substring(1, 1)) * 9;
            total += int.Parse(cpfSemFormatacao.Substring(2, 1)) * 8;
            total += int.Parse(cpfSemFormatacao.Substring(3, 1)) * 7;
            total += int.Parse(cpfSemFormatacao.Substring(4, 1)) * 6;
            total += int.Parse(cpfSemFormatacao.Substring(5, 1)) * 5;
            total += int.Parse(cpfSemFormatacao.Substring(6, 1)) * 4;
            total += int.Parse(cpfSemFormatacao.Substring(7, 1)) * 3;
            total += int.Parse(cpfSemFormatacao.Substring(8, 1)) * 2;

            var digitoVerificador = total % 11;

            if (digitoVerificador < 2)
                digitoVerificador = 0;
            else
                digitoVerificador = 11 - digitoVerificador;

            if (int.Parse(cpfSemFormatacao.Substring(9, 1)) != digitoVerificador)
                return false;

            total = 0;
            total += int.Parse(cpfSemFormatacao[..1]) * 11;
            total += int.Parse(cpfSemFormatacao.Substring(1, 1)) * 10;
            total += int.Parse(cpfSemFormatacao.Substring(2, 1)) * 9;
            total += int.Parse(cpfSemFormatacao.Substring(3, 1)) * 8;
            total += int.Parse(cpfSemFormatacao.Substring(4, 1)) * 7;
            total += int.Parse(cpfSemFormatacao.Substring(5, 1)) * 6;
            total += int.Parse(cpfSemFormatacao.Substring(6, 1)) * 5;
            total += int.Parse(cpfSemFormatacao.Substring(7, 1)) * 4;
            total += int.Parse(cpfSemFormatacao.Substring(8, 1)) * 3;
            total += int.Parse(cpfSemFormatacao.Substring(9, 1)) * 2;

            digitoVerificador = total % 11;

            if (digitoVerificador < 2)
                digitoVerificador = 0;
            else
                digitoVerificador = 11 - digitoVerificador;

            return int.Parse(cpfSemFormatacao.Substring(10, 1)) == digitoVerificador;
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
