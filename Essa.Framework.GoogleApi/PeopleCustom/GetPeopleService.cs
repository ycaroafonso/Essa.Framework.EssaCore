using Google.Apis.PeopleService.v1;
using Google.Apis.Services;

namespace Essa.Framework.GoogleApi.PeopleCustom
{
    public class GetPeopleService
    {
        public PeopleServiceService Service { get; private set; }

        readonly string ApplicationName = "Google Calendar API .NET Quickstart";

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
