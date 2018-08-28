using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace PhoneBook.Core.CrossCuttingConcerns.Security.Web
{
    public class AuthenticationHelper
    {
        public static void CreateAuthCookie(Guid id, string userName, DateTime expiration, string[] roles, bool rememberMe)
        {
            var authTicket = new FormsAuthenticationTicket(1, userName, DateTime.Now, expiration, rememberMe, CreateAuthTags(userName, roles, id));

            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
        }

        private static string CreateAuthTags(string userName, string[] roles, Guid id)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(userName);
            stringBuilder.Append("|");
            for (int i = 0; i < roles.Length; i++)
            {
                stringBuilder.Append(roles[i]);
                if (i < roles.Length - 1)
                {
                    stringBuilder.Append(",");
                }
            }
            stringBuilder.Append("|");
            stringBuilder.Append(id);
            return stringBuilder.ToString();
        }
    }
}
