using Business_Logic;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
namespace dot_net_final_project.Auth
{
    enum USER : int
    {
        Admin = 1,
        Customer = 2,
        Employee = 3,
        Manager = 4
    }
    public class AdminAccess : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var authheader = actionContext.Request.Headers.Authorization;
            if (authheader == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "No token found");
            }
            else
            {
                if (AuthService.IsAuthenticated(authheader.ToString()) && AuthService.IsActive(authheader.ToString()))
                {
                    if (AuthService.UserType(authheader.ToString()) == (int)USER.Admin) { }
                    else
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Admin Access Only");
                    }
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "The token is expired");
                }
            }
            base.OnAuthorization(actionContext);
        }
    }
}