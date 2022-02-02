using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Essa.Framework.GoogleApi
{
    public class AutenticarService
    {
        private Task<UserCredential> _authorize;


        string[] Scopes = {
            CalendarService.Scope.Calendar,
            Google.Apis.PeopleService.v1.PeopleServiceService.Scope.Contacts,
            Google.Apis.PeopleService.v1.PeopleServiceService.Scope.DirectoryReadonly,
            Google.Apis.PeopleService.v1.PeopleServiceService.Scope.UserAddressesRead,
            Google.Apis.PeopleService.v1.PeopleServiceService.Scope.UserBirthdayRead,

            YouTubeService.Scope.YoutubeReadonly
        };



        public AutenticarService(string credentialsPath, string emailautenticacao)
        {
            using (var stream =
                new FileStream(credentialsPath, FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";


                _authorize = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    emailautenticacao,
                    CancellationToken.None,
                    new FileDataStore(credPath, true));

                Credential = _authorize.Result;

            }
        }

        public UserCredential Credential { get; }
    }
}
