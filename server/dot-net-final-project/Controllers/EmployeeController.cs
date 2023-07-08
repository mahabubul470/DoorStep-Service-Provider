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
    public class EmployeeController : ApiController
    {
        [Route("api/employees")]
        [HttpGet]
        public List<EmployeeModel> Get()
        {
            return EmployeeService.Get();
        }
        [Route("api/employee/{id}")]
        [HttpGet]
        public EmployeeModel Get(int id)
        {
            return EmployeeService.Get(id);
        }
        [Route("api/employee/add")]
        [HttpPost]
        public void Add(EmployeeModel user)
        {
            EmployeeService.Add(user);
        }
        [Route("api/employee/edit")]
        [HttpPost]
        public void Edit(EmployeeModel user)
        {
            EmployeeService.Edit(user);
        }
        [Route("api/employee/delete/{id}")]
        [HttpGet]
        public void Delete(int id)
        {
            EmployeeService.Delete(id);
        }
        [Route("api/employee/search/{str}")]
        [HttpGet]
        public List<EmployeeModel> Search(string str)
        {
            return EmployeeService.Search(str);
        }
    }
}
