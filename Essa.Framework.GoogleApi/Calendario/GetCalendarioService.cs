using Google.Apis.Calendar.v3;
using Google.Apis.Services;

namespace Essa.Framework.GoogleApi.Calendario
{
    public class GetCalendarioService
    {
        public CalendarService Service { get; private set; }

        string ApplicationName = "Google Calendar API .NET Quickstart";

        public GetCalendarioService(AutenticarService _autenticarService)
        {

            Service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = _autenticarService.Credential,
                ApplicationName = ApplicationName,
            });

        }
    }
}
