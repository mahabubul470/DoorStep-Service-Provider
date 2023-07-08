using Business_Entity;
using System.Collections.Generic;
using AutoMapper;
using Data_Access.Models;
using Data_Access;
namespace Business_Logic
{
    public class EService
    {
        public static List<ServiceModel> Get()
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
            var da = DataAccessFactory.ServiceDataAcees();
            var data = mapper.Map<List<ServiceModel>>(da.Get());
            return data;
        }

        public static ServiceModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Service, ServiceModel>();
                c.CreateMap<Employee, EmployeeModel>();
                c.CreateMap<Order_Details, OrderDetailsModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.ServiceDataAcees();
            var data = mapper.Map<ServiceModel>(da.Get(id));
            return data;
        }
        public static void Add(ServiceModel service)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Service, ServiceModel>();
                c.CreateMap<Employee, EmployeeModel>();
                c.CreateMap<Order_Details, OrderDetailsModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Service>(service);
            DataAccessFactory.ServiceDataAcees().Add(data);
        }

        public static void Edit(ServiceModel service)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Service, ServiceModel>();
                c.CreateMap<Employee, EmployeeModel>();
                c.CreateMap<Order_Details, OrderDetailsModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Service>(service);
            DataAccessFactory.ServiceDataAcees().Edit(data);
        }

        public static void Delete(int id)
        {
            DataAccessFactory.ServiceDataAcees().Delete(id);
        }


        public static List<ServiceModel> Search(string str)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Service, ServiceModel>();
                c.CreateMap<Employee, EmployeeModel>();
                c.CreateMap<Order_Details, OrderDetailsModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.ServiceDataAcees();
            var data = mapper.Map<List<ServiceModel>>(da.Search(str));
            return data;
        }


    }

}
