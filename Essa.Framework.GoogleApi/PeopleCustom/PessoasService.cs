using Google.Apis.PeopleService.v1;
using Google.Apis.PeopleService.v1.Data;
using System.Collections.Generic;
using System.Linq;

namespace Essa.Framework.GoogleApi.PeopleCustom
{
    public class PessoasService
    {
        private readonly GetPeopleService _getPeopleService;

        public PessoasService(GetPeopleService getPeopleService)
        {
            this._getPeopleService = getPeopleService;
        }








        public IList<Person> ObterTodos(string pageToken = null)
        {

            //List<string> sources = new();
            //sources.Add("DIRECTORY_SOURCE_TYPE_DOMAIN_CONTACT");
            //sources.Add("DIRECTORY_SOURCE_TYPE_DOMAIN_PROFILE");


            //PeopleResource.ListDirectoryPeopleRequest x = _getPeopleService.Service.People.ListDirectoryPeople();
            //var xx = x.Execute().People;


            //var x = _getPeopleService.Service.ContactGroups.List().Execute();


            PeopleResource.ConnectionsResource.ListRequest peopleRequest =
               _getPeopleService.Service.People.Connections.List("people/me");

            if (pageToken != null)
            {
                peopleRequest.PageToken = pageToken;
            }

            peopleRequest.PageSize = 2000;
            peopleRequest.PersonFields = "addresses,ageRanges,biographies,birthdays,calendarUrls,clientData,coverPhotos,emailAddresses,events,externalIds,genders,imClients,interests,locales,locations,memberships,metadata,miscKeywords,names,nicknames,occupations,organizations,phoneNumbers,photos,relations,sipAddresses,skills,urls,userDefined";
            ListConnectionsResponse response = peopleRequest.Execute();
            List<Person> people = response.Connections.ToList();


            //if (response.NextPageToken != null)
            //    people.AddRange(ObterTodos(response.NextPageToken));


            return people;
        }



        public void Cadastrar()
        {
            var c = _getPeopleService.Service.People.CreateContact(new Person
            {
                Names = new List<Name>
                {
                    new Name
                    {
                        DisplayName="__Testeeeee3",
                        GivenName="__Testeeeee3",
                    }
                },
                PhoneNumbers = new List<PhoneNumber>
                {
                    new PhoneNumber
                    {
                        Type= "mobile",
                        Value="(67) 88888-7777"
                    }
                }
            });

            var cc = c.Execute();
        }


    }
}
