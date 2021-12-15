using Data_Access.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access 
{
    class UserRepo : IRepository<User, int>
    {
        PMSEntities db;
        public UserRepo(PMSEntities db)
        {
            this.db = db;
        }

        public void Add(User e)
        {
            db.Users.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.Users.FirstOrDefault(en => en.id == id);
            db.Users.Remove(e);
            db.SaveChanges();
        }

        public void Edit(User e)
        {
            var d = db.Users.FirstOrDefault(en => en.id == e.id);
            db.Entry(d).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.FirstOrDefault(e => e.id == id);
        }

        public  void Confirm(int id)
        {
            var e = db.Users.FirstOrDefault(en => en.id == id);
            e.email = "confirmed";
            db.SaveChanges();
        }
    }
}
