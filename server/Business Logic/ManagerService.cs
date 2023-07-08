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
    public class ManagerService
    {
        public static List<ManagerModel> Get()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserModel>();
                c.CreateMap<Manager, ManagerModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.ManagerDataAcees();
            var data = mapper.Map<List<ManagerModel>>(da.Get());
            return data;
        }

        public static ManagerModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserModel>();
                c.CreateMap<Manager, ManagerModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.UserDataAcees();
            var data = mapper.Map<ManagerModel>(da.Get(id));
            return data;
        }
        public static void Add(ManagerModel user)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<UserModel, User>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Manager>(user);
            DataAccessFactory.ManagerDataAcees().Add(data);
        }

        public static void Edit(ManagerModel user)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ManagerModel, User>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Manager>(user);
            DataAccessFactory.ManagerDataAcees().Edit(data);
        }

        public static void Delete(int id)
        {
            DataAccessFactory.ManagerDataAcees().Delete(id);
        }


        public static List<ManagerModel> Search(string str)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserModel>();
                c.CreateMap<Manager, ManagerModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.ManagerDataAcees();
            var data = mapper.Map<List<ManagerModel>>(da.Search(str));
            return data;
        }


    }

}
