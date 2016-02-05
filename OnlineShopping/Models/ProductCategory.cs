using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopping.Models
{
    [DisplayName("Product Category")]
    [DisplayColumn("Name")]
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Category Name")]
        [Required(ErrorMessage = "Please input category name")]
        [MaxLength(20, ErrorMessage = "Category name less than 20 character")]
        public string Name { get; set; }

    }
}