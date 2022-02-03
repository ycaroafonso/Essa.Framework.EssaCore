using Google.Apis.PeopleService.v1.Data;
using System.Collections.Generic;

namespace Essa.Framework.GoogleApi.Contato
{
    public class GruposService
    {
        private readonly GetPeopleService _getPeopleService;

        public GruposService(GetPeopleService getPeopleService)
        {
            this._getPeopleService = getPeopleService;
        }

        public IList<ContactGroup> ObterTodos()
        {
            var req =
               _getPeopleService.Service.ContactGroups.List().Execute();

            return req.ContactGroups;
        }

    }
}
