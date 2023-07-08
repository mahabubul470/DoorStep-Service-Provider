using Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access 
{
    class OrderDetailsRepo : IRepository<Order_Details, int> 
    {
        Entities db;
        public OrderDetailsRepo(Entities db)
        {
            this.db = db;
        }

        public void Add(Order_Details e)
        {
            db.Order_Details.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.Order_Details.FirstOrDefault(en => en.id == id);
            db.Order_Details.Remove(e);
            db.SaveChanges();
        }

        public void Edit(Order_Details e)
        {
            var d = db.Order_Details.FirstOrDefault(en => en.id == e.id);
            db.Entry(d).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Order_Details> Get()
        {
            return db.Order_Details.ToList();
        }

        public Order_Details Get(int id)
        {
            return db.Order_Details.FirstOrDefault(e => e.id == id);
        }

        public List<Order_Details> Search(string str)
        {
            throw new NotImplementedException();
        }
    }
}
