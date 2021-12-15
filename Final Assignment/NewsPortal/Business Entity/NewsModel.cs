using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entity
{
    public class NewsModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public string image { get; set; }
        public System.DateTime date { get; set; }
        public string comment { get; set; }
        public string react { get; set; }
        public int category_id { get; set; }
        public virtual CategoryModel category { get; set; }
    }
}
