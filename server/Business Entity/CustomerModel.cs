using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entity
{
    public class CustomerModel
    {
        public CustomerModel()
        {
            this.Orders = new HashSet<OrderModel>();
        }

        public int id { get; set; }
        public int userid { get; set; }
        public string delevery_address { get; set; }

        public virtual UserModel User { get; set; }
        public virtual ICollection<OrderModel> Orders { get; set; }
    }
}
