using Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access 
{
    class ApplicationRepo : IRepository<Application, int> 
    {
        Entities db;
        public ApplicationRepo(Entities db)
        {
            this.db = db;
        }

        public void Add(Application e)
        {
            db.Applications.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.Applications.FirstOrDefault(en => en.id == id);
            db.Applications.Remove(e);
            db.SaveChanges();
        }

        public void Edit(Application e)
        {
            var d = db.Applications.FirstOrDefault(en => en.id == e.id);
            db.Entry(d).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Application> Get()
        {
            return db.Applications.ToList();
        }

        public Application Get(int id)
        {
            return db.Applications.FirstOrDefault(e => e.id == id);
        }

        public List<Application> Search(string str)
        {
            throw new NotImplementedException();
        }
    }
}
