using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entity
{
    public class UserModel
    {
        public UserModel()
        {
            this.Customers = new HashSet<CustomerModel>();
            this.Employees = new HashSet<EmployeeModel>();
            this.Managers = new HashSet<ManagerModel>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int usertype { get; set; }
        public string password { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public string address { get; set; }
        public string additional_info { get; set; }
        public string status { get; set; }
        public virtual ICollection<CustomerModel> Customers { get; set; }
        public virtual ICollection<EmployeeModel> Employees { get; set; }
        public virtual ICollection<ManagerModel> Managers { get; set; }
    }
}
