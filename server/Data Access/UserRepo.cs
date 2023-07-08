using Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
namespace Data_Access 
{
    enum USER : int
    {
        Admin = 1,
        Customer = 2,
        Employee = 3,
        Manager = 4
    }
    class UserRepo : IRepository<User, int> , IAuth
    {
        Entities db;
        public UserRepo(Entities db)
        {
            this.db = db;
        }

        public Token Authenticate(User user)
        {
            var u = db.Users.FirstOrDefault(en => en.email.Equals(user.email) && en.password.Equals(user.password));
            Token t = null;
            if (u != null) 
            {
                var tokens = db.Tokens.Where(en => en.userid.Equals(u.id)).ToList();
                foreach (Token tkn in tokens)
                {
                    tkn.expired_at = DateTime.Now;
                }
                string token = Guid.NewGuid().ToString();
                t = new Token();
                t.userid = u.id;
                t.access_token = token;
                t.created_at = DateTime.Now;
                db.Tokens.Add(t);
                db.SaveChanges();
            }
            return t;
        }

        public bool IsAuthenticated(string token)
        {
            var rs = db.Tokens.Any(e => e.access_token.Equals(token) && e.expired_at == null);
            return rs;
        }

        public bool Logout(string token)
        {
            var t = db.Tokens.FirstOrDefault(e => e.access_token.Equals(token));
            if (t != null)
            {
                t.expired_at = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public void Add(User e)
        {
  
            db.Users.Add(e);
            if (e.usertype == (int)USER.Employee)
            {
                var emp = new Employee();
                emp.userid = e.id;
                db.Employees.Add(emp);

            }
            if (e.usertype == (int)USER.Customer)
            {
                var emp = new Customer();
                emp.userid = e.id;
                db.Customers.Remove(emp);

            }
            if (e.usertype == (int)USER.Manager)
            {
                var emp = new Manager();
                emp.userid = e.id;
                db.Managers.Remove(emp);

            }
            db.Users.Remove(e);
            db.SaveChanges();
            db.SaveChanges();

           
        }
        public void Delete(int id)
        {
            var e = db.Users.FirstOrDefault(en => en.id == id);
            if(e.usertype == (int)USER.Employee)
            {
                var emp = db.Employees.FirstOrDefault(en => en.userid == id);
                db.Employees.Remove(emp);
  
            }
            if (e.usertype == (int)USER.Customer)
            {
                var emp = db.Customers.FirstOrDefault(en => en.userid == id);
                db.Customers.Remove(emp);

            }
            if (e.usertype == (int)USER.Manager)
            {
                var emp = db.Managers.FirstOrDefault(en => en.userid == id);
                db.Managers.Remove(emp);

            }
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


        public List<User> Search(string str)
        {
            List<User> users = (from m in db.Users
                                where m.name.Contains(str)
                                select m).ToList();
            return users;
        }

        public int GetUserType(string token)
        {
            var t = db.Tokens.FirstOrDefault(e => e.access_token.Equals(token));
            var u = db.Users.FirstOrDefault(e => e.id == t.userid);
            return u.usertype;
        }

        public bool IsActive(string token)
        {
            var t = db.Tokens.FirstOrDefault(e => e.access_token.Equals(token));
            var u = db.Users.FirstOrDefault(e => e.id == t.userid);
            if (u.status.Trim() == "Active")
                return true;
            return false;
        }
    }
}
