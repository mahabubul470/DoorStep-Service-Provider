using Business_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewsPortal.Controllers
{
    public class NewsController : ApiController
    {
        [Route("api/Student/Names")]
        [HttpGet]
        public List<string> GetNews()
        {
            var n = NewsService.Get();
            return null;
        }
       
    }
}
