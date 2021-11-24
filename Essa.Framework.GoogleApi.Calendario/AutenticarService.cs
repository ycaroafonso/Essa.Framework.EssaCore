using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;

namespace Essa.Framework.GoogleApi.Calendario
{
    public class AutenticarService
    {
        private string credentialsPath;
        private string diretorio;
        private string emailautenticacao;

        public ServiceAccountCredential Credential { get; }

        public AutenticarService(string credentialsPath, string diretorio, string emailautenticacao)
        {
            this.credentialsPath = credentialsPath;
            this.diretorio = diretorio;
            this.emailautenticacao = emailautenticacao;


            Credential =
               new ServiceAccountCredential(
                   new ServiceAccountCredential.Initializer(emailautenticacao)
                   {
                       Scopes = new string[] { CalendarService.Scope.Calendar }
                   }.FromPrivateKey("MUysoiVmmIs6lX5dgg_OjWk8"));

        }
    }
}
