using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entity
{
    public class TokenModel
    {
        public int id { get; set; }
        public int userid { get; set; }
        public string access_token { get; set; }
        public System.DateTime created_at { get; set; }
        public Nullable<System.DateTime> expired_at { get; set; }
    }
}
