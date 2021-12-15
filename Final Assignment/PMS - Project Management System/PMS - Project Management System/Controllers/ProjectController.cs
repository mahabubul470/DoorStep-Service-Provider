using PMS___Project_Management_System.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business_Entity;
using Business_Logic;
using System.Web.Http.Cors;

namespace PMS___Project_Management_System.Controllers
{
   
    public class ProjectController : ApiController
    {
        [Route("api/project/create")]
        [HttpGet]
        [TrimStringsFilter]
        public void Create(ProjectModel p)
        {
            ProjectService.Add(p);
        }



        [Route("api/projects")]
        [HttpGet]
        public List<ProjectModel> Get()
        {
            return ProjectService.Get();
        }

        [Route("api/projects/1")]
        [HttpGet]
        [TrimStringsFilter]
        public string Get1()
        {
            return "ok";
        }



    }
}
