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
    public class ManagerController : ApiController
    {
        [Route("api/managers")]
        [HttpGet]
        public List<ManagerModel> Get()
        {
            return ManagerService.Get();
        }
        [Route("api/manager/{id}")]
        [HttpGet]
        public ManagerModel Get(int id)
        {
            return ManagerService.Get(id);
        }
        [Route("api/manager/add")]
        [HttpPost]
        public void Add(ManagerModel user)
        {
            ManagerService.Add(user);
        }
        [Route("api/manager/edit")]
        [HttpPost]
        public void Edit(ManagerModel user)
        {
            ManagerService.Edit(user);
        }
        [Route("api/manager/delete/{id}")]
        [HttpGet]
        public void Delete(int id)
        {
            ManagerService.Delete(id);
        }
        [Route("api/manager/search/{str}")]
        [HttpGet]
        public List<ManagerModel> Search(string str)
        {
            return ManagerService.Search(str);
        }
    }
}
