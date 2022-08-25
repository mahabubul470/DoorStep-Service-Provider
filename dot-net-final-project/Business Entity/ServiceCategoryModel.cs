using System.Collections.Generic;
namespace Business_Entity
{
    public class ServiceCategoryModel
    {

        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string details { get; set; }
        public virtual ICollection<ServiceModel> Services { get; set; }
    }
}
