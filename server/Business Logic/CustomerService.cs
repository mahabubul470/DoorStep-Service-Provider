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
    public class CustomerService
    {
        public static List<CustomerModel> Get()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserModel>();
                c.CreateMap<Customer, CustomerModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.CustomerDataAcees();
            var data = mapper.Map<List<CustomerModel>>(da.Get());
            return data;
        }

        public static CustomerModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserModel>();
                c.CreateMap<Customer, ManagerModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.UserDataAcees();
            var data = mapper.Map<CustomerModel>(da.Get(id));
            return data;
        }
        public static void Add(CustomerModel user)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<CustomerModel, User>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Customer>(user);
            DataAccessFactory.CustomerDataAcees().Add(data);
        }

        public static void Edit(CustomerModel user)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<CustomerModel, User>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Customer>(user);
            DataAccessFactory.CustomerDataAcees().Edit(data);
        }

        public static void Delete(int id)
        {
            DataAccessFactory.CustomerDataAcees().Delete(id);
        }


        public static List<CustomerModel> Search(string str)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserModel>();
                c.CreateMap<Customer, CustomerModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.CustomerDataAcees();
            var data = mapper.Map<List<CustomerModel>>(da.Search(str));
            return data;
        }


    }

}
