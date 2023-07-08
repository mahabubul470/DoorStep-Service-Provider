using Business_Entity;
using System.Collections.Generic;
using AutoMapper;
using Data_Access.Models;
using Data_Access;
namespace Business_Logic
{
    public class OrderDetailsService
    {
        public static List<OrderDetailsModel> Get()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Order, OrderModel>();
                c.CreateMap<Order_Details, OrderDetailsModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.OrderDetailsDataAcees();
            var data = mapper.Map<List<OrderDetailsModel>>(da.Get());
            return data;
        }

        public static OrderDetailsModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {


                c.CreateMap<User, UserModel>();
                c.CreateMap<Employee, EmployeeModel>();
                c.CreateMap<Manager, ManagerModel>();
                c.CreateMap<Customer, CustomerModel>();
                c.CreateMap<Order, OrderModel>();
                c.CreateMap<Order_Details, OrderDetailsModel>();
                c.CreateMap<Service_Category, ServiceCategoryModel>();
                c.CreateMap<Service, ServiceModel>();
                c.CreateMap<Application, ApplicationModel>();

                c.CreateMap<User, UserModel>().ReverseMap();
                c.CreateMap<Employee, EmployeeModel>().ReverseMap();
                c.CreateMap<Manager, ManagerModel>().ReverseMap();
                c.CreateMap<Customer, CustomerModel>().ReverseMap();
                c.CreateMap<Order, OrderModel>().ReverseMap();
                c.CreateMap<Order_Details, OrderDetailsModel>().ReverseMap();
                c.CreateMap<Service_Category, ServiceCategoryModel>().ReverseMap();
                c.CreateMap<Service, ServiceModel>().ReverseMap();
                c.CreateMap<Application, ApplicationModel>().ReverseMap();

            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.OrderDataAcees();
            var x = da.Get(id);
            var data = mapper.Map<OrderDetailsModel>(x);
            return data;
        }
        public static void Add(OrderDetailsModel order)
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

        public static void Edit(OrderDetailsModel order)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Order, OrderModel>();
                c.CreateMap<Order_Details, OrderDetailsModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Order_Details>(order);
            DataAccessFactory.OrderDetailsDataAcees().Edit(data);
        }

        public static void Delete(int id)
        {
            DataAccessFactory.OrderDetailsDataAcees().Delete(id);
        }


        public static List<OrderDetailsModel> Search(string str)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Order, OrderModel>();
                c.CreateMap<Order_Details, OrderDetailsModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.OrderDetailsDataAcees();
            var data = mapper.Map<List<OrderDetailsModel>>(da.Search(str));
            return data;
        }


    }

}
