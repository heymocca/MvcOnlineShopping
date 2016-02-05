using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace OnlineShopping.Models
{

    [DisplayName("Product Detail")]
    [DisplayColumn("Name")]

    public class Product
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Product Category")]
        [Required]
        public ProductCategory ProductCategory { get; set; }

        [DisplayName("Product Name")]
        [Required(ErrorMessage = "Please input product name")]
        [MaxLength(60, ErrorMessage = "Product name should be less than 60 character")]
        public string Name { get; set; }

        [DisplayName("Product Description")]
        [Required(ErrorMessage = "Please input product description")]
        [MaxLength(250, ErrorMessage = "Product description should be less than 250 character")]
        public string Description { get; set; }

        [DisplayName("Product Color")]
        [Required(ErrorMessage = "Please select color")]
        public Color Color { get; set; }

        [DisplayName("Product Price")]
        [Required(ErrorMessage = "Please input product price")]
        [Range(99, 1000, ErrorMessage = "Product price should be between 99 ~ 1000")]
        public int Price { get; set; }

        [DisplayName("Publish Time")]
        [Description("If no publish time, then never be published")]
        public DateTime? PublishOn { get; set; }
    }
}