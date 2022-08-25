using Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access 
{
    class ServiceCategoryRepo : IRepository<Service_Category, int> 
    {
        Entities db;
        public ServiceCategoryRepo(Entities db)
        {
            this.db = db;
        }

        public void Add(Service_Category e)
        {
            db.Service_Category.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.Service_Category.FirstOrDefault(en => en.id == id);
            db.Service_Category.Remove(e);
            db.SaveChanges();
        }

        public void Edit(Service_Category e)
        {
            var d = db.Service_Category.FirstOrDefault(en => en.id == e.id);
            db.Entry(d).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Service_Category> Get()
        {
            return db.Service_Category.ToList();
        }

        public Service_Category Get(int id)
        {
            return db.Service_Category.FirstOrDefault(e => e.id == id);
        }

        public List<Service_Category> Search(string str)
        {
            throw new NotImplementedException();
        }
    }
}
