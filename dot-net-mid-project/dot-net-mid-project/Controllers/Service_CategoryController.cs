using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dot_net_mid_project.Auth;
using dot_net_mid_project.Models;

namespace dot_net_mid_project.Controllers
{
    [AdminAccess]
    public class Service_CategoryController : Controller
    {
        private Entities db = new Entities();

        // GET: Service_Category
        public ActionResult Index()
        {
            return View(db.Service_Category.ToList());
        }

        public ActionResult Search(string search)
        {
            var services = from m in db.Service_Category
                           where m.name.Contains(search)
                           select m;
            return View("Index", services.ToList());
        }


        // GET: Service_Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service_Category service_Category = db.Service_Category.Find(id);
            if (service_Category == null)
            {
                return HttpNotFound();
            }
            return View(service_Category);
        }

        // GET: Service_Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Service_Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Service_Category service_Category)
        {
            if (ModelState.IsValid)
            {
                db.Service_Category.Add(service_Category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(service_Category);
        }

        // GET: Service_Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service_Category service_Category = db.Service_Category.Find(id);
            if (service_Category == null)
            {
                return HttpNotFound();
            }
            return View(service_Category);
        }

        // POST: Service_Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,type,details")] Service_Category service_Category)
        {
            if (ModelState.IsValid)
            {
                service_Category.name = service_Category.name.Trim();
                service_Category.type = service_Category.type.Trim();
                db.Entry(service_Category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service_Category);
        }

        // GET: Service_Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service_Category service_Category = db.Service_Category.Find(id);
            if (service_Category == null)
            {
                return HttpNotFound();
            }
            return View(service_Category);
        }

        // POST: Service_Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service_Category service_Category = db.Service_Category.Find(id);
            db.Service_Category.Remove(service_Category);
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
