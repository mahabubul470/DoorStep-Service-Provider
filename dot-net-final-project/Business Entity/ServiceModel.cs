using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entity
{
    public class ServiceModel
    {
        public ServiceModel()
        {
            this.Employees = new HashSet<EmployeeModel>();
            this.Order_Details = new HashSet<OrderDetailsModel>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public string details { get; set; }
        public double price { get; set; }
        public string status { get; set; }
        public string type { get; set; }

        public virtual ICollection<EmployeeModel> Employees { get; set; }
        public virtual ICollection<OrderDetailsModel> Order_Details { get; set; }
        public virtual ServiceCategoryModel Service_Category { get; set; }
    }
}
