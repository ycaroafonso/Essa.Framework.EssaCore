using Essa.Framework.Util.Extensions;
using System;

namespace Essa.Framework.Util.Util;

public static class UtilJWT
{
    public static void DecodificarJwt(string token)
    {
        // Dividir o token em suas três partes
        var partes = token.Split('.');
        if (partes.Length != 3)
        {
            Console.WriteLine("Token inválido.");
            return;
        }

        string payload = partes[1];

        var jsonBytes = Base64UrlDecode(payload);

        var json = System.Text.Encoding.UTF8.GetString(jsonBytes);


        var claims = json.ToObjectFromJson<dynamic>();
        foreach (var claim in claims)
        {
            Console.WriteLine($"{claim.Key}: {claim.Value}");
        }
    }

    private static byte[] Base64UrlDecode(string base64Url)
    {
        string base64 = base64Url.Replace('-', '+').Replace('_', '/');
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
        return Convert.FromBase64String(base64);
    }
}
