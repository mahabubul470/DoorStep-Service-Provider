using Business_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data_Access.Models;
using Data_Access;
namespace Business_Logic
{
    public class UserService
    {
        public static List<UserModel> Get()
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
            var da = DataAccessFactory.UserDataAcees();
            var data = mapper.Map<List<UserModel>>(da.Get());
            return data;
        }

        public static UserModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserModel>().ReverseMap();
                c.CreateMap<Customer, CustomerModel>().ReverseMap();
                c.CreateMap<Employee, EmployeeModel>().ReverseMap();
                c.CreateMap<Manager, ManagerModel>().ReverseMap();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.UserDataAcees();
            var data = mapper.Map<UserModel>(da.Get(id));
            return data;
        }
        public static void Add(UserModel user)
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
            var data = mapper.Map<User>(user);
            DataAccessFactory.UserDataAcees().Add(data);
        }

        public static void Edit(UserModel user)
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
            var data = mapper.Map<User>(user);
            DataAccessFactory.UserDataAcees().Edit(data);
        }

        public static void Delete(int id)
        {
            DataAccessFactory.UserDataAcees().Delete(id);
        }


        public static List<UserModel> Search(string str)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserModel>().ReverseMap();
                c.CreateMap<Customer, CustomerModel>().ReverseMap();
                c.CreateMap<Employee, EmployeeModel>().ReverseMap();
                c.CreateMap<Manager, ManagerModel>().ReverseMap();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.UserDataAcees();
            var data = mapper.Map<List<UserModel>>(da.Search(str));
            return data;
        }

        public static void Block(int id)
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
            var da = DataAccessFactory.UserDataAcees();
            var user = mapper.Map<UserModel>(da.Get(id));
            user.status = "Blocked";
            Edit(user);
        }

        public static void Active(int id)
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
            var da = DataAccessFactory.UserDataAcees();
            var user = mapper.Map<UserModel>(da.Get(id));
            user.status = "Active";
            Edit(user);
        }



    }

}
