using dot_net_mid_project.Auth;
using dot_net_mid_project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dot_net_mid_project.Controllers
{
    [AdminAccess]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            ViewData["usercount"] = UserRepository.GetUserCount();
            ViewData["customercount"] = UserRepository.GetCustomerCount();
            ViewData["employeecount"] = UserRepository.GetEmployeeCount();
            ViewData["managercount"] = UserRepository.GetManagerCount();
            ViewData["servicecount"] = UserRepository.GetServiceCount();
            ViewData["ordercount"] = UserRepository.GetOrderCount();
            return View();
        }
    }
}