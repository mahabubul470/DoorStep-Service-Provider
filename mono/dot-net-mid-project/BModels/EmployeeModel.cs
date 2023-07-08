using dot_net_mid_project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dot_net_mid_project.BModels
{
    public class EmployeeModel
    {

         
         public int  id { set; get; }
        [Required]
        [Display(Name = "name")]
        public string name{ set; get; }
         public string email { set; get; }
         public string phone{ set; get; }
         public double ? salary{ set; get; }
         public string work_area { set; get; }
         public string work_status { set; get; }
         public int? service_id { set; get; }
    }
}