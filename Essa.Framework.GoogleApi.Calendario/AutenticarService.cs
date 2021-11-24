using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;

namespace Essa.Framework.GoogleApi.Calendario
{
    public class AutenticarService
    {
        private string _credentialsPath;
        private string _diretorio;
        private string _emailautenticacao;

        string[] Scopes = { CalendarService.Scope.Calendar };



        public AutenticarService(string credentialsPath, string diretorio, string emailautenticacao)
        {
            _credentialsPath = credentialsPath;
            _diretorio = diretorio;
            _emailautenticacao = emailautenticacao;




            using (var stream =
                new FileStream(credentialsPath, FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";

                Credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    emailautenticacao,
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

        }

        public UserCredential Credential { get; }
    }
}
