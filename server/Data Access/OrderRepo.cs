using Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access 
{
    class OrderRepo : IRepository<Order, int> ,IOrder
    {
        Entities db;
        public OrderRepo(Entities db)
        {
            this.db = db;
        }

        public void Add(Order e)
        {
            db.Orders.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.Orders.FirstOrDefault(en => en.id == id);
            db.Orders.Remove(e);
            db.SaveChanges();
        }

        public void Edit(Order e)
        {
            var d = db.Orders.FirstOrDefault(en => en.id == e.id);
            db.Entry(d).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Order> Get()
        {
            return db.Orders.ToList();
        }

        public Order Get(int id)
        {
            return db.Orders.FirstOrDefault(e => e.id == id);
        }

        public void Process(int id)
        {
            var order = Get(id);
            order.status = "Processing";
            Edit(order);
        }

        public List<Order> Search(string str)
        {
            throw new NotImplementedException();
        }
    }
}
