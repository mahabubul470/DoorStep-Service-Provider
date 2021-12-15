using Business_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    class CategoryRepo : IRepository<category, int>
    {

        Entities entities;
        
        public CategoryRepo(Entities entities)
        {
            this.entities = entities;
        }
        public void Add(category e)
        {
            entities.categories.Add(e);
            entities.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = entities.categories.FirstOrDefault(en => en.id == id);
            entities.categories.Remove(e);
            entities.SaveChanges();
        }

        public void Edit(category e)
        {
            var d = entities.categories.FirstOrDefault(en => en.id == e.id);
            entities.Entry(d).CurrentValues.SetValues(e);
            entities.SaveChanges();
        }

        public List<category> Get()
        {
            return entities.categories.ToList();
        }

        public category Get(int id)
        {
            return entities.categories.FirstOrDefault(e => e.id == id);
        }
    }
}
