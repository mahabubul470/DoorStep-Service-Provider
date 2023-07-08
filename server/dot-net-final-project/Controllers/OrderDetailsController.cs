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
    public class OrderDetailsController : ApiController
    {
    
        [Route("api/order-details/{id}")]
        [HttpGet]
        public OrderDetailsModel Get(int id)
        {
            return OrderDetailsService.Get(id);
        }
        [Route("api/order-details/add")]
        [HttpPost]
        public void Add(OrderDetailsModel order_details)
        {
            OrderDetailsService.Add(order_details);
        }
        [Route("api/order-details/edit")]
        [HttpPost]
        public void Edit(OrderDetailsModel order_details)
        {
            OrderDetailsService.Edit(order_details);
        }
        [Route("api/order-details/delete/{id}")]
        [HttpGet]
        public void Delete(int id)
        {
            OrderService.Delete(id);
        }
        [Route("api/order-details/search/{str}")]
        [HttpGet]
        public List<OrderDetailsModel> Search(string str)
        {
            return OrderDetailsService.Search(str);
        }
    }
}
