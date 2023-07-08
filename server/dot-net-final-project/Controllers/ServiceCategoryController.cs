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
    public class ServiceCategoryController : ApiController
    {
        [Route("api/service-categories")]
        [HttpGet]
        public List<ServiceCategoryModel> Get()
        {
            return ServiceCategoryService.Get();
        }
        [Route("api/service-categories/{id}")]
        [HttpGet]
        public ServiceCategoryModel Get(int id)
        {
            return ServiceCategoryService.Get(id);
        }
        [Route("api/service-categories/add")]
        [HttpPost]
        public void Add(ServiceCategoryModel service_category)
        {
            ServiceCategoryService.Add(service_category);
        }
        [Route("api/service-categories/edit")]
        [HttpPost]
        public void Edit(ServiceCategoryModel service_category)
        {
            ServiceCategoryService.Edit(service_category);
        }
        [Route("api/service-categories/delete/{id}")]
        [HttpGet]
        public void Delete(int id)
        {
            EService.Delete(id);
        }

        [Route("api/service-categories/search/{str}")]
        [HttpGet]
        public List<ServiceCategoryModel> Search(string str)
        {
            return ServiceCategoryService.Search(str);
        }
    }
}
