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
    public class EmployeesController : Controller
    {
        private Entities db = new Entities();

        // GET: Employees
        public ActionResult Index()
        {
            List<Employee> employees = db.Employees.ToList();
            List<Manager> managers = db.Managers.ToList();
            List<User> users = db.Users.ToList();
            var res = users.Join(
                employees,
                e => e.id,
                d => d.userid,
                (user, employee) => new EmployeeModel
                {
                    id = user.id,
                    name = user.name,
                    email = user.email,
                    phone = user.phone,
                    salary = employee.salary,
                    work_area=employee.work_area,
                    work_status=employee.work_status,
                    service_id = employee.service_id
                }
            );

            return View(res.ToList());
        }


        public ActionResult Search(string search)
        {
            List<User> users = (from m in db.Users
                                where m.name.Contains(search)
                                select m).ToList();
            List<Employee> employees  = db.Employees.ToList();
            var res = users.Join(
               employees,
               e => e.id,
               d => d.userid,
               (user, employee) => new EmployeeModel
               {
                   id = user.id,
                   name = user.name,
                   email = user.email,
                   phone = user.phone,
                   salary = employee.salary,
                   work_area = employee.work_area,
                   work_status = employee.work_status,
                   service_id = employee.service_id
               }
           );

            return View("Index", res.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.service_id = new SelectList(db.Services, "id", "name");
            ViewBag.userid = new SelectList(db.Users, "id", "name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,userid,salary,service_id,work_area,work_status")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.service_id = new SelectList(db.Services, "id", "name", employee.service_id);
            ViewBag.userid = new SelectList(db.Users, "id", "name", employee.userid);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee = (from m in db.Employees
                            where m.userid == id
                            select m).FirstOrDefault();
            User user = db.Users.Find(id);
            var res = new EmployeeModel
            {
                id = user.id,
                name = user.name,
                email = user.email,
                phone = user.phone,
                salary = employee.salary,
                work_area = employee.work_area,
                work_status = employee.work_status,
                service_id = employee.service_id,
            };
           
            return View(res);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeModel employee)
        {
            var emp = (from m in db.Employees
                            where m.userid == employee.id
                            select m).FirstOrDefault();
            User user = db.Users.Find(employee.id);

            user.name = employee.name;
            user.phone = employee.phone;
            user.email = employee.email;
            emp.salary = employee.salary;
            emp.work_area = employee.work_area;
            emp.work_status = employee.work_status;

            db.Users.Add(user);
            db.Employees.Add(emp);
            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            var user = db.Users.Find(employee.userid);
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
