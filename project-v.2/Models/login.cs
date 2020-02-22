using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project_v._2.Models
{
    public class login
    {
        [Required]
        [StringLength(50, MinimumLength = 4)]
        [Display(Name = "UserName")]
        public string username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 4)]
        [Display(Name = "PassWord")]
        public string password { get; set; }
    }
}
