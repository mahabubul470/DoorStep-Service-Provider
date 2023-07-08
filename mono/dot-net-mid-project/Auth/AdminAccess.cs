using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dot_net_mid_project.Repository;
using System.Web.Mvc;

namespace dot_net_mid_project.Auth
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
        public class AdminAccess : AuthorizeAttribute
        {
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
            var user = UserRepository.GetUser(httpContext.User.Identity.Name);
                if (base.AuthorizeCore(httpContext))
                {
                    
                    if (user.usertype == (int) USER.Admin )
                    {
                        return true;
                    }

                }
                return false;

            }
        }
}