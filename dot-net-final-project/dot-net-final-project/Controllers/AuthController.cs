using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Business_Entity;
using Business_Logic;
using dot_net_final_project.Auth;

namespace dot_net_final_project.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AuthController : ApiController
    {
        [Route("api/logout")]
        [HttpGet]
        public HttpResponseMessage Logout()
        {
            var token = Request.Headers.Authorization.ToString();
            if (token != null)
            {
                var rs = AuthService.Logout(token);
                if (rs)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Sucessfully logged out");
                }

            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid token to logout");
        }
        [Route("api/login")]
        [HttpPost]
        public HttpResponseMessage Login(UserModel user)
        {
            //call to service
            var token = AuthService.Authenticate(user);
            if (token != null && AuthService.IsActive(token.access_token))
            {

                return Request.CreateResponse(HttpStatusCode.OK, token);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "User not found");
        }
    }
}
