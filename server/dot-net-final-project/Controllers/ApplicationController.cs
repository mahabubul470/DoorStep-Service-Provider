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
    [AdminAccess]
    public class ApplicationController : ApiController
    {
        [Route("api/applications")]
        [HttpGet]
        public List<ApplicationModel> Get()
        {
            return ApplicationService.Get();
        }
        [Route("api/application/{id}")]
        [HttpGet]
        public ApplicationModel Get(int id)
        {
            return ApplicationService.Get(id);
        }
        [Route("api/application/add")]
        [HttpPost]
        public void Add(ApplicationModel application)
        {
            ApplicationService.Add(application);
        }
        [Route("api/application/edit")]
        [HttpPost]
        public void Edit(ApplicationModel application)
        {
            ApplicationService.Edit(application);
        }
        [Route("api/application/delete/{id}")]
        [HttpGet]
        public void Delete(int id)
        {
            OrderService.Delete(id);
        }
        [Route("api/application/search/{str}")]
        [HttpGet]
        public List<ApplicationModel> Search(string str)
        {
            return ApplicationService.Search(str);
        }
    }
}
