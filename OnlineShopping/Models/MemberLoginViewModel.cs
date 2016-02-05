using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShopping.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OnlineShopping.Models
{
    public class MemberLoginViewModel
    {
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please input your email")]
        [Required(ErrorMessage = "Please input {0}")]
        public string Email { get; set; }

        [DisplayName("Password")]
        [DataType(DataType.Password)]        
        [Required(ErrorMessage = "Please input {0}")]
        public string Password { get; set; }

    }
}