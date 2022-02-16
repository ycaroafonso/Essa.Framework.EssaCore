using EssaGestaoCore.DTO.GoogleApi.ContatoApi;
using Google.Apis.PeopleService.v1.Data;
using System.Collections.Generic;
using System.Linq;
using static Google.Apis.PeopleService.v1.PeopleResource;

namespace Essa.Framework.GoogleApi.Contato
{
    public class CadastrarOuAtualizarService
    {
        private readonly GetPeopleService _getPeopleService;
        private readonly CadastrarContatoApiEnvioDTO Envio;

        public CadastrarContatoApiEnvioDTO Retorno { get; private set; }

        public CadastrarOuAtualizarService(GetPeopleService getPeopleService, CadastrarContatoApiEnvioDTO envio)
        {
            _getPeopleService = getPeopleService;
            Envio = envio;
        }


        public Person Person { get; private set; }

        private void Cadastrar()
        {
            Person = new Person
            {
                Names = new List<Name>
                {
                    new Name
                    {
                        DisplayName=Envio.Nome,
                        GivenName= Envio.Nome,
                    }
                },
            };



            if (Envio.Telefones.Any())
            {
                Person.PhoneNumbers = new List<PhoneNumber>();

                foreach (var item in Envio.Telefones)
                    Person.PhoneNumbers.Add(new PhoneNumber
                    {
                        Type = item.Type,
                        Value = item.Value
                    });
            }

            if (Envio.Emails.Any())
            {
                Person.EmailAddresses = new List<EmailAddress>();
                foreach (var item in Envio.Emails)
                    Person.EmailAddresses.Add(new EmailAddress
                    {
                        Type = item.Type,
                        Value = item.Value
                    });
            }

            if (Envio.Enderecos != null)
            {
                Person.Addresses = new List<Address>();

                foreach (var item in Envio.Enderecos)
                    Person.Addresses.Add(new Address
                    {
                        StreetAddress = item.Linha1,
                        ExtendedAddress = item.Linha2,
                        City = item.Cidade,
                        Region = item.Uf,
                        Type = item.Type
                    });
            }

            if (Envio.Marcadores != null)
            {
                Person.Memberships = new List<Membership>();

                foreach (var item in Envio.Marcadores.Where(c => c.codigogooglecontatoapi != null))
                    Person.Memberships.Add(new Membership
                    {
                        ContactGroupMembership = new ContactGroupMembership
                        {
                            ContactGroupResourceName = item.descricaomarcador,
                            ContactGroupId = item.codigogooglecontatoapi
                        }
                    });
            }
        }

        public void Executar()
        {
            Cadastrar();

            if (string.IsNullOrEmpty(Envio.codigogooglecontatoapi))
            {
                CreateContactRequest c = _getPeopleService.Service.People.CreateContact(Person);

                Person = c.Execute();
            }
            else
            {
                UpdateContactRequest c = _getPeopleService.Service.People.UpdateContact(Person, Envio.codigogooglecontatoapi);

                Person = c.Execute();
            }


        }
    }
}
