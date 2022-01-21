using Google.Apis.PeopleService.v1;
using Google.Apis.PeopleService.v1.Data;
using System.Collections.Generic;
using System.Linq;

namespace Essa.Framework.GoogleApi.PeopleCustom
{
    public class ObterPessoasService
    {
        private readonly GetPeopleService _getPeopleService;

        public ObterPessoasService(GetPeopleService getPeopleService)
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
            peopleRequest.PersonFields = "birthdays,names,EmailAddresses,metadata,addresses,photos,coverPhotos";
            ListConnectionsResponse response = peopleRequest.Execute();
            List<Person> people = response.Connections.ToList();


            //if (response.NextPageToken != null)
            //    people.AddRange(ObterTodos(response.NextPageToken));


            return people;
        }
    }
}
