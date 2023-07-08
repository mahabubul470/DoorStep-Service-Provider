using Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access 
{
    class EmployeeRepo : IRepository<Employee, int> 
    {
        Entities db;
        public EmployeeRepo(Entities db)
        {
            this.db = db;
        }

        public void Add(Employee e)
        {
            db.Employees.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.Employees.FirstOrDefault(en => en.id == id);
            db.Employees.Remove(e);
            db.SaveChanges();
        }

        public void Edit(Employee e)
        {
            var d = db.Employees.FirstOrDefault(en => en.id == e.id);
            db.Entry(d).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Employee> Get()
        {
            return db.Employees.ToList();
        }

        public Employee Get(int id)
        {
            return db.Employees.FirstOrDefault(e => e.id == id);
        }

        public List<Employee> Search(string str)
        {
            throw new NotImplementedException();
        }
    }
}
