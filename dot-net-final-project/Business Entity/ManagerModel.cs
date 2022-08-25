using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entity
{
    public class ManagerModel
    {
        public int id { get; set; }
        public Nullable<int> userid { get; set; }
        public Nullable<double> salary { get; set; }

        public virtual UserModel User { get; set; }
    }
}
