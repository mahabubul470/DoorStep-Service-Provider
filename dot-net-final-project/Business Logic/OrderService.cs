using Business_Entity;
using System.Collections.Generic;
using AutoMapper;
using Data_Access.Models;
using Data_Access;
namespace Business_Logic
{
    public class OrderService
    {
        public static List<OrderModel> Get()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserModel>().ReverseMap();
                c.CreateMap<Customer, CustomerModel>().ReverseMap();
                c.CreateMap<Order, OrderModel>().ReverseMap();
                c.CreateMap<Order_Details, OrderDetailsModel>().ReverseMap();
                c.CreateMap<Service, ServiceModel>().ReverseMap();
                c.CreateMap<Employee, EmployeeModel>().ReverseMap();
                c.CreateMap<Manager, ManagerModel>().ReverseMap();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.OrderDataAcees();
            var x = da.Get();
            var data = mapper.Map<List<OrderModel>>(x);
            return data;
        }

        public static OrderModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Order, OrderModel>();
                c.CreateMap<Order_Details, OrderDetailsModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.OrderDataAcees();
            var data = mapper.Map<OrderModel>(da.Get(id));
            return data;
        }
        public static void Add(OrderModel order)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Order, OrderModel>();
                c.CreateMap<Order_Details, OrderDetailsModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Order>(order);
            DataAccessFactory.OrderDataAcees().Add(data);
        }

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

        public static void Delete(int id)
        {
            DataAccessFactory.OrderDataAcees().Delete(id);
        }

        public static void Process(int id)
        {
            DataAccessFactory.OrderProcessDataAcees().Process(id);
        }

        public static List<OrderModel> Search(string str)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Order, OrderModel>();
                c.CreateMap<Order_Details, OrderDetailsModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.OrderDataAcees();
            var data = mapper.Map<List<OrderModel>>(da.Search(str));
            return data;
        }


    }

}
