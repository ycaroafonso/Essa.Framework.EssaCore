using Google.Apis.Calendar.v3;
using Google.Apis.PeopleService.v1;
using Google.Apis.PeopleService.v1.Data;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essa.Framework.GoogleApi.PeopleCustom
{
    public class GetPeopleService
    {
        public PeopleServiceService Service { get; private set; }

        string ApplicationName = "Google Calendar API .NET Quickstart";

        public GetPeopleService(AutenticarService _autenticarService)
        {

            Service = new PeopleServiceService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = _autenticarService.Credential,
                ApplicationName = ApplicationName,
            });

        }
    }
}
