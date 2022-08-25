using Business_Entity;
using System.Collections.Generic;
using AutoMapper;
using Data_Access.Models;
using Data_Access;
namespace Business_Logic
{
    public class ApplicationService
    {
        public static List<ApplicationModel> Get()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Application, ApplicationModel>();
                c.CreateMap<Employee, EmployeeModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.ApplicationDataAcees();
            var data = mapper.Map<List<ApplicationModel>>(da.Get());
            return data;
        }
        public static ApplicationModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Application, ApplicationModel>();
                c.CreateMap<Employee, EmployeeModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.ApplicationDataAcees();
            var data = mapper.Map<ApplicationModel>(da.Get(id));
            return data;
        }
        public static void Add(ApplicationModel application)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Application, ApplicationModel>();
                c.CreateMap<Employee, EmployeeModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Application>(application);
            DataAccessFactory.ApplicationDataAcees().Add(data);
        }
        public static void Edit(ApplicationModel application)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Application, ApplicationModel>();
                c.CreateMap<Employee, EmployeeModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Application>(application);
            DataAccessFactory.ApplicationDataAcees().Edit(data);
        }
        public static void Delete(int id)
        {
            DataAccessFactory.ApplicationDataAcees().Delete(id);
        }
        public static List<ApplicationModel> Search(string str)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Application, ApplicationModel>();
                c.CreateMap<Employee, EmployeeModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.OrderDataAcees();
            var data = mapper.Map<List<ApplicationModel>>(da.Search(str));
            return data;
        }
    }

}
