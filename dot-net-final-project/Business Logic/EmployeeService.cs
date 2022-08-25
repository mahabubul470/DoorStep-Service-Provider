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
    public class EmployeeService
    {
        public static List<EmployeeModel> Get()
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
            var da = DataAccessFactory.EmployeeDataAcees();
            var data = mapper.Map<List<EmployeeModel>>(da.Get());
            return data;
        }

        public static EmployeeModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserModel>();
                c.CreateMap<Employee, EmployeeModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.EmployeeDataAcees();
            var data = mapper.Map<EmployeeModel>(da.Get(id));
            return data;
        }
        public static void Add(EmployeeModel employee)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<EmployeeModel, Employee>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Employee>(employee);
            DataAccessFactory.EmployeeDataAcees().Add(data);
        }

        public static void Edit(EmployeeModel employee)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<EmployeeModel, User>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Employee>(employee);
            DataAccessFactory.EmployeeDataAcees().Edit(data);
        }

        public static void Delete(int id)
        {
            DataAccessFactory.EmployeeDataAcees().Delete(id);
        }
         

        public static List<EmployeeModel> Search(string str)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserModel>();
                c.CreateMap<Employee, EmployeeModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.EmployeeDataAcees();
            var data = mapper.Map<List<EmployeeModel>>(da.Search(str));
            return data;
        }

 

    }

}
