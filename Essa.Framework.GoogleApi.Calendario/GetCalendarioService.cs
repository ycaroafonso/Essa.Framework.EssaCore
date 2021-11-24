using Google.Apis.Calendar.v3;
using Google.Apis.Services;

namespace Essa.Framework.GoogleApi.Calendario
{
    public class GetCalendarioService
    {
        private AutenticarService _autenticarService;

        public GetCalendarioService(AutenticarService autenticarService)
        {
            _autenticarService = autenticarService;



            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = autenticarService.Credential,
            });

            
        }
    }
}
