using Business_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Data_Access
{
    public class NewsRepo : IRepository<news, int>
    {
        Entities entities;
        public NewsRepo(Entities entities)
        {
            this.entities = entities;
        }
        public void Add(news e)
        {
            entities.news.Add(e);
            entities.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = entities.news.FirstOrDefault(en => en.id == id);
            entities.news.Remove(e);
            entities.SaveChanges();
        }

        public void Edit(news e)
        {
            var d = entities.news.FirstOrDefault(en => en.id == e.id);
            entities.Entry(d).CurrentValues.SetValues(e);
            entities.SaveChanges();
        }

        public List<news> Get()
        {
            return entities.news.ToList();
        }

        public news Get(int id)
        {
            return entities.news.FirstOrDefault(e => e.id == id);
        }
    }
}
