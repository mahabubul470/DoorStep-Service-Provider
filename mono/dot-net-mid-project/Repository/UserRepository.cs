using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dot_net_mid_project.Models;

namespace dot_net_mid_project.Repository
{
    enum USER : int
    {
        Admin = 1,
        Customer = 2,
        Employee = 3,
        Manager = 4
    }


    public class UserRepository
    {
        static Entities Entities;
        static UserRepository()
        {
            Entities = new Entities();

        }
        public static User GetUser(string _id)
        {
            int ? id = null;
            if (Int32.TryParse(_id, out int res))
            {
                 id = res;
            }
            var rs = (from user in Entities.Users
                     where user.id == id
                     select user).FirstOrDefault();
            return rs;
        }

        public static int GetUserCount()
        {
            IQueryable<User> records = Entities.Users;
            var count = records.Count();
            return count;
        }

        public static int GetServiceCount()
        {
            IQueryable<Service> records = Entities.Services;
            var count = records.Count();
            return count;
        }



        public static int GetCustomerCount()
        {
            IQueryable<Customer> records = Entities.Customers;
            var count = records.Count();
            return count;
        }

        public static int GetManagerCount()
        {
            IQueryable<Manager> records = Entities.Managers;
            var count = records.Count();
            return count;
        }

        public static int GetOrderCount()
        {
            IQueryable<Order> records = from m in Entities.Orders
                                        where m.status.Contains("completed")
                                        select m;
            var count = records.Count();
            return count;
        }

        public static int GetEmployeeCount()
        {
            IQueryable<Employee> records = Entities.Employees;
            var count = records.Count();
            return count;
        }

        public static User Authenticate(string email, string password)
        {
            var user = (from users in Entities.Users
                     where users.email.Trim() == email.Trim() &&
                     users.password.Trim() == password.Trim()
                     select users).FirstOrDefault();
            return user;
        }


        public static bool CreateUser(User user)
        {

            Entities.Users.Add(user);
            Entities.SaveChanges();
            return true;
        }

        public static bool BlockUser(int id)
        {
            var user = Entities.Users.Find(id);
            user.additional_info = "Blocked";
            Entities.SaveChanges();
            return true;
        }

        public static bool ActivateUser(int id)
        {
            var user = Entities.Users.Find(id);
            user.additional_info = "Active";
            Entities.SaveChanges();
            return true;
        }


            public static bool CreateEmployee(int id)
        {
            Employee emp = new Employee()
            {
                userid = id
            };
            
            Entities.Employees.Add(emp);
            Entities.SaveChanges();
            return true;
        }

        public static bool CreateManager(int id)
        {
            Manager manager = new Manager()
            {
                userid = id
            };
            Entities.Managers.Add(manager);
            Entities.SaveChanges();
            return true;
        }

        public static bool CreateCustomer(int id)
        {
            Customer customer = new Customer()
            {
                userid = id
            };
            Entities.Customers.Add(customer);
            Entities.SaveChanges();
            return true;
        }

    }
}