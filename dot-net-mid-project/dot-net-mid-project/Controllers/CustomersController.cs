using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dot_net_mid_project.Models;
using dot_net_mid_project.BModels;
using dot_net_mid_project.Auth;

namespace dot_net_mid_project.Controllers
{
    [AdminAccess]
    public class CustomersController : Controller
    {
        private Entities db = new Entities();

        // GET: Customers
        public ActionResult Index()
        {
            List<User> users = db.Users.ToList();
            List<Customer> customers = db.Customers.ToList();
            var res = users.Join(
                customers,
                e => e.id,
                d=>d.userid,
                (user, customer) =>new CustomerModel{
                    id = user.id,
                    name = user.name,
                    address = customer.delevery_address,
                    email = user.email,
                    phone = user.phone
                }     
            );
            return View(res.ToList());
        }



        public ActionResult Search(string search)
        {
            List<User> users = (from m in db.Users
                                where m.name.Contains(search)
                                select m).ToList();
            List<Customer> customers = db.Customers.ToList();
            var res =  users.Join(
                customers,
                e => e.id,
                d => d.userid,
                (user, customer) => new CustomerModel
                {
                    id = user.id,
                    name = user.name,
                    address = customer.delevery_address,
                    email = user.email,
                    phone = user.phone
                }
            );

            return View("Index",res.ToList());
        }


        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.userid = new SelectList(db.Users, "id", "name");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,userid,delevery_address")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.userid = new SelectList(db.Users, "id", "name", customer.userid);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.userid = new SelectList(db.Users, "id", "name", customer.userid);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,userid,delevery_address")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userid = new SelectList(db.Users, "id", "name", customer.userid);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            var user = db.Users.Find(customer.userid);
            db.Users.Remove(user);
            db.SaveChanges();
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
