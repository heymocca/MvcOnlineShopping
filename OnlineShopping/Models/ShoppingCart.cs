using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Models
{
    public class ShoppingCart
    {
        [DisplayName("Selected Products")]
        [Required]
        public Product Product { get; set; }

        [DisplayName("Quantity")]
        [Required]
        public int Amount { get; set; }


    }
}