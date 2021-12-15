using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dot_net_mid_project.BModels
{
    public class UserModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(25, ErrorMessage = "Must be under 25 characters")]
        public string name { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [StringLength(15, ErrorMessage = "Must be under 15 characters")]
        public string phone { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                            ErrorMessage = "Please enter a valid email address")]
        public string email { get; set; }
        public Nullable<int> address_id { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public int usertype { get; set; }
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,10}$",
                            ErrorMessage = "Please enter a valid password address")]
        public string password { get; set; }
        public string RePassword { get; set; }

    }
}