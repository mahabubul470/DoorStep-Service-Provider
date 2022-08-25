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
    public class OrderController : ApiController
    {
        [Route("api/orders")]
        [HttpGet]
        public List<OrderModel> Get()
        {
            return OrderService.Get();
        }
        [Route("api/order/{id}")]
        [HttpGet]
        public OrderModel Get(int id)
        {
            return OrderService.Get(id);
        }
        [Route("api/order/add")]
        [HttpPost]
        public void Add(OrderModel order)
        {
            OrderService.Add(order);
        }
        [Route("api/order/edit")]
        [HttpPost]
        public void Edit(OrderModel order)
        {
            OrderService.Edit(order);
        }
        [Route("api/order/delete/{id}")]
        [HttpGet]
        public void Delete(int id)
        {
            OrderService.Delete(id);
        }
        [Route("api/order/process/{id}")]
        [HttpGet]
        public void Process(int id)
        {
            OrderService.Process(id);
        }
        [Route("api/order/search/{str}")]
        [HttpGet]
        public List<OrderModel> Search(string str)
        {
            return OrderService.Search(str);
        }
    }
}
