using System.Net.Mail;

namespace Essa.Framework.Util.Util
{
    public static class EmailUtil
    {
        public static bool IsValid(string email)
        {
            var valid = true;

            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }
    }
}
