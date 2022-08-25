using Business_Entity;
using System.Collections.Generic;
using AutoMapper;
using Data_Access.Models;
using Data_Access;
namespace Business_Logic
{
    public class ServiceCategoryService
    {
        public static List<ServiceCategoryModel> Get()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Service, ServiceModel>();
                c.CreateMap<Service_Category, ServiceCategoryModel>();

            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.ServiceCategoryDataAcees();
            var data = mapper.Map<List<ServiceCategoryModel>>(da.Get());
            return data;
        }

        public static ServiceCategoryModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Service, ServiceModel>();
                c.CreateMap<Service_Category, ServiceCategoryModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.ServiceCategoryDataAcees();
            var data = mapper.Map<ServiceCategoryModel>(da.Get(id));
            return data;
        }
        public static void Add(ServiceCategoryModel service_category)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Service, ServiceModel>();
                c.CreateMap<Service_Category, ServiceCategoryModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Service>(service_category);
            DataAccessFactory.ServiceCategoryDataAcees().Add(data);
        }

        public static void Edit(ServiceCategoryModel service_category)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Service, ServiceModel>();
                c.CreateMap<Service_Category, ServiceCategoryModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Service>(service_category);
            DataAccessFactory.ServiceCategoryDataAcees().Edit(data);
        }

        public static void Delete(int id)
        {
            DataAccessFactory.ServiceCategoryDataAcees().Delete(id);
        }


        public static List<ServiceCategoryModel> Search(string str)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Service, ServiceModel>();
                c.CreateMap<Service_Category, ServiceCategoryModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.ServiceCategoryDataAcees();
            var data = mapper.Map<List<ServiceCategoryModel>>(da.Search(str));
            return data;
        }


    }

}
