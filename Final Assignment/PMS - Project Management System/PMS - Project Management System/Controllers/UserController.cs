using Business_Entity;
using Business_Logic;
using Newtonsoft.Json;
using PMS___Project_Management_System.Attributes;
using System;
using System.Collections.Generic;
using System.Web.Http;


namespace PMS___Project_Management_System.Controllers
{
    public class UserController : ApiController
    {
        // GET api/<controller>
        [Route("api/users")]
        [HttpGet]
        [TrimStringsFilter]
        public List<UserModel> Get()
        {
           return UserService.Get();
        }
        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        } 

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}