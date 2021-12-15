using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entity
{
    public class ProjectModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string state { get; set; }
        public string confirm_status { get; set; }
        public virtual ICollection<UserModel> Users { get; set; }
    }
}
