using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business_Entity;
using Business_Logic;

namespace NewsPortal_Api.Controllers
{
    public class StudentController1 : ApiController
    {
        [Route("api/news/get")]
        [HttpGet]
        public List<NewsModel> GetNews()
        {
            var data = NewsService.Get();
            return data;
        }

        [Route("api/news/add")]

        [HttpPost]
        public void AddNews(NewsModel n)
        {
            NewsService.Add(n);
           
        }
        [Route("api/news/edit")]
        [HttpPost]
        public void EditNews(NewsModel n)
        {
            NewsService.Edit(n);
        }

        [Route("api/news/delete/{id}")]
        public void Delete(int id)
        {
            NewsService.Remove(id);
        }


        [Route("api/news/category/get")]
        [HttpGet]
        public List<NewsModel> GetCategory()
        {
            var data = NewsService.Get();
            return data;
        }

        [Route("api/news/category/add")]

        [HttpPost]
        public void AddCategory(NewsModel n)
        {
            NewsService.Add(n);

        }
        [Route("api/news/category/edit")]
        [HttpPost]
        public void EditCategory(NewsModel n)
        {
            NewsService.Edit(n);
        }

        [Route("api/news/category/delete/{id}")]
        public void DeleteCategory(int id)
        {
            NewsService.Remove(id);
        }

        [HttpPost]
        public void AddComment(NewsModel n)
        {
            NewsService.AddComment(n);

        }
        [HttpPost]
        public void AddReact(NewsModel n)
        {
            NewsService.AddReact(n);

        }

    }
}