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
    public class ProjectService
    {
        public static void Add(ProjectModel s)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<UserModel, User>();
                c.CreateMap<Project, ProjectModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Project>(s);
            DataAccessFactory.ProjectDataAcees().Add(data);
        }

        public static List<ProjectModel> Get()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserModel>();
                c.CreateMap<Project, ProjectModel>();

            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.ProjectDataAcees();
            var data = mapper.Map<List<ProjectModel>>(da.Get());
            return data;
        }
    }

}
