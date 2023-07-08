using Business_Entity;
using System.Collections.Generic;
using AutoMapper;
using Data_Access.Models;
using Data_Access;
namespace Business_Logic
{
    public class OrderProcessService
    {
    

        public static void Edit(OrderModel order)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Order, OrderModel>();
                c.CreateMap<Order_Details, OrderDetailsModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Order>(order);
            DataAccessFactory.OrderDataAcees().Edit(data);
        }



    }

}
