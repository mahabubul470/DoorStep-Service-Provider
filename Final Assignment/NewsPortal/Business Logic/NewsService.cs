using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Text;
using System.Threading.Tasks;
using Business_Entity;
using Data_Access;
namespace Business_Logic
{
    public class NewsService
    {
        public static List<NewsModel> Get()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<news, NewsModel>();
                c.CreateMap<category, CategoryModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.NewsDataAcees();
            var data = mapper.Map<List<NewsModel>>(da.Get());
            return data;
        }
        public static List<NewsModel> GetNewsByCategory(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<news, NewsModel>();
                c.CreateMap<category, CategoryModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.NewsDataAcees();
            var data = mapper.Map<List<NewsModel>>(da.Get().Where(e => e.category.id == id));
            return data;
        }

        public static List<NewsModel> GetNewsByDate(DateTime date)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<news, NewsModel>();
                c.CreateMap<category, CategoryModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.NewsDataAcees();
            var data = mapper.Map<List<NewsModel>>(da.Get().Where(e => e.date == date));
            return data;
        }

        public static List<NewsModel> GetNewsByCategory(DateTime date)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<news, NewsModel>();
                c.CreateMap<category, CategoryModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.NewsDataAcees();
            var data = mapper.Map<List<NewsModel>>(da.Get().Where(e => e.date == date));
            return data;
        }

        public static void Add(NewsModel s)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<NewsModel, news>();

            });
            var mapper = new Mapper(config);
            var data = mapper.Map<news>(s);
            DataAccessFactory.NewsDataAcees().Add(data);
        }

        public static void Remove(int id)
        {
            DataAccessFactory.NewsDataAcees().Delete(id);
        }

        public static void Edit(NewsModel newsModel)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<NewsModel, news>();

            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.NewsDataAcees();
            var data = mapper.Map<news>(da.Get().Where(e => e.id == newsModel.id));
            DataAccessFactory.NewsDataAcees().Edit(data);
        }

        public static void AddComment(NewsModel newsModel)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<NewsModel, news>();

            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.NewsDataAcees();
            var data = mapper.Map<news>(da.Get().Where(e=> e.id == newsModel.id));
            data.comment = newsModel.comment;
            DataAccessFactory.NewsDataAcees().Add(data);
        }

        public static void AddReact(NewsModel newsModel)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<NewsModel, news>();

            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.NewsDataAcees();
            var data = mapper.Map<news>(da.Get().Where(e => e.id == newsModel.id));
            data.react = newsModel.react;
            DataAccessFactory.NewsDataAcees().Add(data);
        }

    }
}
