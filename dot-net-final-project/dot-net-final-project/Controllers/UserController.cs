using Business_Entity;
using Business_Logic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Http;
using dot_net_final_project.Auth;
using System.Web.Http.Cors;

namespace dot_net_final_project.Controllers
{
    [EnableCors("*", "*", "*")]
    [AdminAccess]
    public class UserController : ApiController
    {
       
        [Route("api/users")]
        [HttpGet]
        public List<UserModel> Get()
        {
           return UserService.Get();
        }
        [Route("api/user/{id}")]
        [HttpGet]
        public UserModel Get(int id)
        {
            return UserService.Get(id);
        }
        [Route("api/user/add")]
        [HttpPost]
        public void Add(UserModel user)
        {
            UserService.Add(user);     
        }
        [Route("api/edit/add")]
        [HttpPost]
        public void Edit(UserModel user)
        {
            UserService.Edit(user);
        }
        [Route("api/user/delete/{id}")]
        [HttpGet]
        public void Delete(int id)
        {
            UserService.Delete(id);
        }
        [Route("api/user/search/{str}")]
        [HttpGet]
        public List<UserModel> Search(string str)
        {
            return UserService.Search(str);
        }

        [Route("api/user/block/{id}")]
        [HttpGet]
        public void Block(int id)
        {
            UserService.Block(id);
        }
        [Route("api/user/active/{id}")]
        [HttpGet]
        public void Active(int id)
        {
            UserService.Active(id);
        }
    }
}