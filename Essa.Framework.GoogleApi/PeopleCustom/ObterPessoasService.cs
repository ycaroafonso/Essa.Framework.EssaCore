using Google.Apis.PeopleService.v1;
using Google.Apis.PeopleService.v1.Data;
using System.Collections.Generic;

namespace Essa.Framework.GoogleApi.PeopleCustom
{
    public class ObterPessoasService
    {
        private readonly GetPeopleService _getPeopleService;

        public ObterPessoasService(GetPeopleService getPeopleService)
        {
            this._getPeopleService = getPeopleService;
        }


        public IList<Person> ObterTodos()
        {

            //List<string> sources = new();
            //sources.Add("DIRECTORY_SOURCE_TYPE_DOMAIN_CONTACT");
            //sources.Add("DIRECTORY_SOURCE_TYPE_DOMAIN_PROFILE");


            //PeopleResource.ListDirectoryPeopleRequest x = _getPeopleService.Service.People.ListDirectoryPeople();
            //var xx = x.Execute().People;


            //var x = _getPeopleService.Service.ContactGroups.List().Execute();


            PeopleResource.ConnectionsResource.ListRequest peopleRequest =
               _getPeopleService.Service.People.Connections.List("people/me");
            peopleRequest.PageSize = 2000;
            peopleRequest.PersonFields = "birthdays,names,EmailAddresses,metadata,addresses,photos,coverPhotos";
            ListConnectionsResponse response = peopleRequest.Execute();
            IList<Person> people = response.Connections;

            return people;
        }
    }
}
