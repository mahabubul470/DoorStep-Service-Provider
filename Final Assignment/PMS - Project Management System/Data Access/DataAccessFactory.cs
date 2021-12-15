using Data_Access.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    public class DataAccessFactory
    {
        static PMSEntities db;
        static DataAccessFactory()
        {
            db = new PMSEntities();
        }
        public static IRepository<User, int> UserDataAcees()
        {
            return new UserRepo(db);
        }
        public static IRepository<Project, int> ProjectDataAcees()
        {
            return new ProjectRepo(db);
        }
    }
}
