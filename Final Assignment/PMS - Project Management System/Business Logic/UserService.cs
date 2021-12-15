using Business_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data_Access.Model;
using Data_Access;
namespace Business_Logic
{
    public class UserService
    {
        public static List<UserModel> Get()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserModel>();
                c.CreateMap<Project, ProjectModel>();

            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.UserDataAcees();
            var data = mapper.Map<List<UserModel>>(da.Get());
            return data;
        }
        public static void Add(UserModel s)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<UserModel, User>();
                c.CreateMap<Project, ProjectModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<User>(s);
            DataAccessFactory.UserDataAcees().Add(data);
        }

        public static void Confirm(int id)
        {
            DataAccessFactory.UserDataAcees().Delete(id);
      
        }
    }

}
