using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dot_net_mid_project.Auth;
using dot_net_mid_project.BModels;
using dot_net_mid_project.Models;
using dot_net_mid_project.Repository;

namespace dot_net_mid_project.Controllers
{
    [AdminAccess]
    public class UsersController : Controller
    {
        private Entities db = new Entities();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users;
            return View(users.ToList());
        }

        public ActionResult Search(string search)
        {
            var users = from m in db.Users
                                      where m.name.Contains(search)
                                      select m;
            return View("Index",users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
           
            return View();
        }

        public ActionResult Block(int id)
        {
            UserRepository.BlockUser(id);
            return RedirectToAction("Index");
        }

        public ActionResult Activate(int id)
        {
            UserRepository.ActivateUser(id);
            return RedirectToAction("Index");
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,phone,email,usertype,password")] UserModel user)
        {
            
            var u1 = new User()
            {
                name = user.name,
                email = user.email,
                password = user.password,
                phone = user.phone,
                usertype = user.usertype,
                additional_info = "Active"

            };
            
          
            if (ModelState.IsValid)
            {
               
                db.Users.Add(u1);
                try
                {
                    
                    if(u1.usertype == (int)USER.Employee)
                    {
                        db.SaveChanges();
                        UserRepository.CreateEmployee(u1.id);
                       
                    }
                    else if (u1.usertype == (int)USER.Manager)
                    {
                        db.SaveChanges();
                        UserRepository.CreateManager(u1.id);
                       
                    }
                    else 
                    {
                        u1.usertype = (int)USER.Customer;
                        db.SaveChanges();
                        UserRepository.CreateCustomer(u1.id);
                    }
                    ViewData["msg"] = " User added ";
                    return RedirectToAction("Index");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                        }
                    }
                }
                
            }
            return View(u1);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
           
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,phone,email,address_id,usertype,password,created_at,updated_at")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
     
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            if(user.usertype == (int)USER.Employee)
            {
                var employe = (from m in db.Employees
                                where m.userid == user.id
                                select m).FirstOrDefault();
                db.Employees.Remove(employe);
                db.Users.Remove(user);
            }
            else if(user.usertype == (int)USER.Manager)
            {
                var manager = (from m in db.Managers
                               where m.userid == user.id
                               select m).FirstOrDefault();
                db.Managers.Remove(manager);
                db.Users.Remove(user);
            }
            else if (user.usertype == (int)USER.Customer)
            {
                var customer = (from m in db.Customers
                               where m.userid == user.id
                               select m).FirstOrDefault();
                db.Customers.Remove(customer);
                db.Users.Remove(user);
            }
            try
            {

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
