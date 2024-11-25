using System;

namespace Essa.Framework.Util.Util
{
    public static class UtilCPF
    {
        public static string GerarCPF()
        {
            // Função para calcular os dígitos verificadores
            int CalcularDigito(string baseCpf)
            {
                int soma = 0;
                for (int i = 0; i < baseCpf.Length; i++)
                {
                    soma += int.Parse(baseCpf[i].ToString()) * (baseCpf.Length + 1 - i);
                }
                int resto = soma % 11;
                return resto < 2 ? 0 : 11 - resto;
            }

            // Gerar os 9 primeiros dígitos aleatórios
            Random random = new Random();
            string baseCpf = "";
            for (int i = 0; i < 9; i++)
            {
                baseCpf += random.Next(0, 10).ToString();
            }

            // Calcular os dois dígitos verificadores
            int primeiroDigito = CalcularDigito(baseCpf);
            int segundoDigito = CalcularDigito(baseCpf + primeiroDigito);

            // Montar o CPF completo (sem formatação)
            return baseCpf + primeiroDigito + segundoDigito;
        }

    }
}
