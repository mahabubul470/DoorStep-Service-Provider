using Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access 
{
    class ServiceRepo : IRepository<Service, int> 
    {
        Entities db;
        public ServiceRepo(Entities db)
        {
            this.db = db;
        }

        public void Add(Service e)
        {
            db.Services.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.Services.FirstOrDefault(en => en.id == id);
            db.Services.Remove(e);
            db.SaveChanges();
        }

        public void Edit(Service e)
        {
            var d = db.Services.FirstOrDefault(en => en.id == e.id);
            db.Entry(d).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Service> Get()
        {
            return db.Services.ToList();
        }

        public Service Get(int id)
        {
            return db.Services.FirstOrDefault(e => e.id == id);
        }

        public List<Service> Search(string str)
        {
            throw new NotImplementedException();
        }
    }
}
