using Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access 
{
    class ManagerRepo : IRepository<Manager, int> 
    {
        Entities db;
        public ManagerRepo(Entities db)
        {
            this.db = db;
        }

        public void Add(Manager e)
        {
            db.Managers.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.Managers.FirstOrDefault(en => en.id == id);
            db.Managers.Remove(e);
            db.SaveChanges();
        }

        public void Edit(Manager e)
        {
            var d = db.Managers.FirstOrDefault(en => en.id == e.id);
            db.Entry(d).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Manager> Get()
        {
            return db.Managers.ToList();
        }

        public Manager Get(int id)
        {
            return db.Managers.FirstOrDefault(e => e.id == id);
        }

        public List<Manager> Search(string str)
        {
            throw new NotImplementedException();
        }
    }
}
