using Business_Logic;
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
        public static IRepository<news, int> NewsDataAcees()
        {
            return new NewsRepo(db);
        }
        public static IRepository<category, int> CategoryDataAccess()
        {
            return new CategoryRepo(db);
        }


    }
}
