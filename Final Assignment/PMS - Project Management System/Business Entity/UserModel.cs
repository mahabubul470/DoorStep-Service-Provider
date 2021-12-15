using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entity
{
    public class UserModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public Nullable<int> type { get; set; }
        public int project_id { get; set; }
    }
}
