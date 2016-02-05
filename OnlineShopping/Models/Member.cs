﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace OnlineShopping.Models
{
    [DisplayName("Member Info")]
    [DisplayColumn("Name")]

    public class Member
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("User Email")]
        [Required(ErrorMessage = "Please input your email")]
        [Description("Use email login")]
        [MaxLength(250, ErrorMessage = "Email should be less than 250 character")]
        public string Email { get; set; }

        [DisplayName("User Password")]
        [Required(ErrorMessage = "Please input your password")]
        [Description("Use SHA1-Secure Hash Algorithm encrpt password, then transform to HEX, length at 40 ")]
        [MaxLength(40, ErrorMessage = "Password should be less than 40 character")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("User Name")]
        [Required(ErrorMessage = "Please input your name")]
        [MaxLength(10, ErrorMessage = "User Name should be less than 10 character")]
        public string UserName { get; set; }

        [DisplayName("Nick Name")]
        [Required(ErrorMessage = "Please input your nick name")]
        [MaxLength(10, ErrorMessage = "Nick Name should be less than 10 character")]
        public string NickName { get; set; }


        [DisplayName("User Register Date")]
        public DateTime RegisterOn { get; set; }

        [DisplayName("Authentication Code")]
        [MaxLength(36)]
        [Description("If AuthCode == null, whose email has been verified")]
        public string AuthCode { get; set; }
    }
}