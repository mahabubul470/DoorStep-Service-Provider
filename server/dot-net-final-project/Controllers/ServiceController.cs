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
    public class ServiceController : ApiController
    {
        [Route("api/services")]
        [HttpGet]
        public List<ServiceModel> Get()
        {
            return EService.Get();
        }
        [Route("api/service/{id}")]
        [HttpGet]
        public ServiceModel Get(int id)
        {
            return EService.Get(id);
        }
        [Route("api/service/add")]
        [HttpPost]
        public void Add(ServiceModel service)
        {
            EService.Add(service);
        }
        [Route("api/service/edit")]
        [HttpPost]
        public void Edit(ServiceModel service)
        {
            EService.Edit(service);
        }
        [Route("api/service/delete/{id}")]
        [HttpGet]
        public void Delete(int id)
        {
            EService.Delete(id);
        }

        [Route("api/service/search/{str}")]
        [HttpGet]
        public List<ServiceModel> Search(string str)
        {
            return EService.Search(str);
        }
    }
}
