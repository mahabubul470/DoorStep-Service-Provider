using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entity
{
    public class EmployeeModel
    {
        public EmployeeModel()
        {
            this.Applications = new HashSet<ApplicationModel>();
        }

        public int id { get; set; }
        public int userid { get; set; }
        public Nullable<double> salary { get; set; }
        public Nullable<int> service_id { get; set; }
        public string work_area { get; set; }
        public string work_status { get; set; }

        public virtual ICollection<ApplicationModel> Applications { get; set; }
        public virtual ServiceModel Service { get; set; }
        public virtual UserModel User { get; set; }
    }
}
