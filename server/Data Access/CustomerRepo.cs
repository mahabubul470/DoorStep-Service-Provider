using Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access 
{
    class CustomerRepo : IRepository<Customer, int> 
    {
        Entities db;
        public CustomerRepo(Entities db)
        {
            this.db = db;
        }

        public void Add(Customer e)
        {
            db.Customers.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.Customers.FirstOrDefault(en => en.id == id);
            db.Customers.Remove(e);
            db.SaveChanges();
        }

        public void Edit(Customer e)
        {
            var d = db.Users.FirstOrDefault(en => en.id == e.id);
            db.Entry(d).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Customer> Get()
        {
            return db.Customers.ToList();
        }

        public Customer Get(int id)
        {
            return db.Customers.FirstOrDefault(e => e.id == id);
        }

        public List<Customer> Search(string str)
        {
            throw new NotImplementedException();
        }
    }
}
