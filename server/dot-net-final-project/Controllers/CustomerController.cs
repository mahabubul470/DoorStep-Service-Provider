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
    public class CustomerController : ApiController
    {
        [Route("api/customers")]
        [HttpGet]
        public List<CustomerModel> Get()
        {
            return CustomerService.Get();
        }
        [Route("api/customer/{id}")]
        [HttpGet]
        public CustomerModel Get(int id)
        {
            return CustomerService.Get(id);
        }
        [Route("api/customer/add")]
        [HttpPost]
        public void Add(CustomerModel customer)
        {
            CustomerService.Add(customer);
        }
        [Route("api/customer/edit")]
        [HttpPost]
        public void Edit(CustomerModel customer)
        {
            CustomerService.Edit(customer);
        }
        [Route("api/customer/delete/{id}")]
        [HttpGet]
        public void Delete(int id)
        {
            EmployeeService.Delete(id);
        }
        [Route("api/customer/search/{str}")]
        [HttpGet]
        public List<CustomerModel> Search(string str)
        {
            return CustomerService.Search(str);
        }
    }
}
