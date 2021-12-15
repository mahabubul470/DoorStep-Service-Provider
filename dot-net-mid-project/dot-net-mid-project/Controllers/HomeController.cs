using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using dot_net_mid_project.Auth;
using dot_net_mid_project.Models;
using dot_net_mid_project.Repository;
namespace dot_net_mid_project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Signup()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Signup(User user)
        {

            var u1 = new User()
            {
                name = user.name,
                email = user.email,
                password = user.password,
                phone = user.phone,
                usertype = (int)USER.Customer,
                additional_info = "Active"

            };
            try
            {
                UserRepository.CreateUser(u1);
                UserRepository.CreateCustomer(u1.id);

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

           
            return View();
        }

        
        public ActionResult Login(User input_user)
        {
            var  user = UserRepository.Authenticate(input_user.email, input_user.password);
            if (user != null)
            {
                if (user.additional_info.Trim() == "Active")
                {
                    FormsAuthentication.SetAuthCookie(user.id.ToString(), true);
                    Session["userid"] = user.id;
                    Session["username"] = user.name;
                    if (user.usertype == (int)USER.Admin)
                        return RedirectToAction("Index", "DashBoard");
                    else if (user.usertype == (int)USER.Customer)
                        return RedirectToAction("Index", "CustomerHome");
                    else if (user.usertype == (int)USER.Employee)
                        return RedirectToAction("Index", "EmployeeHome");
                    else if (user.usertype == (int)USER.Manager)
                        return RedirectToAction("Index", "ManagerHome");

                    else return RedirectToAction("Index");
                }
                else
                {
                    ViewData["messeage"] = "Account Blocked";
                    return View("Index");
                }
            }
            ViewData["messeage"] = "Wrong Credentials";
            return View("Index");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}