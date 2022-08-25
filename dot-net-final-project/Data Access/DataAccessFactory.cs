using Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    public class DataAccessFactory
    {
        static Entities db;
        static DataAccessFactory()
        {
            db = new Entities();
        }
        public static IRepository<User, int> UserDataAcees()
        {
            return new UserRepo(db);
        }

        public static IRepository<Token, string> TokenDataAcees()
        {
            return new TokenRepo(db);
        }

        public static IAuth AuthDataAccess()
        {
            return new UserRepo(db);
        }

        public static IRepository<Employee, int> EmployeeDataAcees()
        {
            return new EmployeeRepo(db);
        }

        public static IRepository<Manager, int> ManagerDataAcees()
        {
            return new ManagerRepo(db);
        }

        public static IRepository<Customer, int> CustomerDataAcees()
        {
            return new CustomerRepo(db);
        }

        public static IRepository<Order, int> OrderDataAcees()
        {
            return new OrderRepo(db);
        }

        public static IOrder OrderProcessDataAcees()
        {
            return new OrderRepo(db);
        }

        public static IRepository<Order_Details, int> OrderDetailsDataAcees()
        {
            return new OrderDetailsRepo(db);
        }

        public static IRepository<Service, int> ServiceDataAcees()
        {
            return new ServiceRepo(db);
        }

        public static IRepository<Service, int> ServiceCategoryDataAcees()
        {
            return new ServiceRepo(db);
        }

        public static IRepository<Application, int> ApplicationDataAcees()
        {
            return new ApplicationRepo(db);
        }


    }
}
