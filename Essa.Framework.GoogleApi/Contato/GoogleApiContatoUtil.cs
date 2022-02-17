using EssaGestaoCore.DTO.GoogleApi.ContatoApi;
using Google.Apis.PeopleService.v1.Data;
using System.Collections.Generic;
using System.Linq;

namespace Essa.Framework.GoogleApi.Contato
{
    public static class GoogleApiContatoUtil
    {
        public static CadastrarContatoApiEnvioDTO Converter(Person person, string codigoimportacao)
        {
            var envio = new CadastrarContatoApiEnvioDTO()
            {
                Telefones = new List<CadastrarContatoTelefone>(),

                codigoimportacao = codigoimportacao,
                codigogooglecontatoapi = person.ResourceName
            };

            envio.Nome = person.Names.FirstOrDefault()?.DisplayName;


            if (person.PhoneNumbers != null)
                foreach (var item in person.PhoneNumbers)
                    envio.Telefones.Add(new CadastrarContatoTelefone
                    {
                        Type = item.Type,
                        Value = item.Value
                    });


            if (person.EmailAddresses != null)
                foreach (var item in person.EmailAddresses)
                    envio.Emails.Add(new CadastrarContatoEmail(item.Value));

            if (person.Addresses != null)
                foreach (var item in person.Addresses)
                    envio.Enderecos.Add(new CadastrarContatoEndereco(item.StreetAddress, item.ExtendedAddress, item.City, item.Region));

            return envio;
        }
    }
}
