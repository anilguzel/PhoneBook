using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using PostSharp.Aspects;

namespace PhoneBook.Core.Aspects.Postsharp.AuthorizationAspect
{
    [Serializable]
    public class SecuredOperation : OnMethodBoundaryAspect
    {
        public string Roles { get; set; }

        public override void OnEntry(MethodExecutionArgs args)
        {
            string[] roles = Roles.Split(',');
            bool isAuthorized = false;
            for (int i = 0; i < roles.Length; i++)
            {
                if (System.Threading.Thread.CurrentPrincipal.IsInRole(roles[i]))
                {
                    isAuthorized = true;
                }
            }

            if (isAuthorized == false)
            {
                throw new SecurityException("You are not authorized.");

            }

        }
    }
}