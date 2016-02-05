using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Models
{
    [DisplayName("Order Detail")]
    [DisplayColumn("Name")]
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Order Header")]
        [Required]
        public virtual OrderHeader OrderHeader { get; set; }

        [DisplayName("Products")]
        [Required]
        public Product Product { get; set; }

        [DisplayName("Price")]
        [Required(ErrorMessage = "Please input product price")]
        [Range(99, 1000, ErrorMessage = "Product price should be between 99 ~ 1000")]
        [Description("The total price may not different due to promotion or discount")]
        [DataType(DataType.Currency)]
        public int Price { get; set; }

        [DisplayName("Quantity")]
        [Required]
        public int Amount { get; set; }
    }
}