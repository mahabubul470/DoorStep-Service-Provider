using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entity
{
    public class OrderModel
    {
        public OrderModel()
        {
            this.Order_Details = new HashSet<OrderDetailsModel>();
        }

        public int id { get; set; }
        public int customer_id { get; set; }
        public System.DateTime order_place_date { get; set; }
        public string status { get; set; }
        public string delevery_address { get; set; }

        public virtual CustomerModel Customer { get; set; }
        public virtual ICollection<OrderDetailsModel> Order_Details { get; set; }
    }
}
