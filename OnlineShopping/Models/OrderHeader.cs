using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace OnlineShopping.Models
{
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("User Name")]
        [Required]
        public virtual Member Member { get; set; }

        [DisplayName("Receiver Name")]
        [Required(ErrorMessage = "Please input receiver name")]
        [MaxLength(40, ErrorMessage = "Receiver name should be less than 40 characters")]
        [Description("The user who bought product may not be the receiver")]
        public string ContactName { get; set; }

        [DisplayName("Contact Number")]
        [Required(ErrorMessage = "Please input contact number")]
        [MaxLength(25, ErrorMessage = "Contact number should be less than 25")]
        [DataType(DataType.PhoneNumber)]
        public string ContactNumber { get; set; }

        [DisplayName("Delivery Address")]
        [Required(ErrorMessage = "Please input delivery address")]
        public string DeliveryAddress { get; set; }


        [DisplayName("Total Price")]
        [Required]
        [DataType(DataType.Currency)]
        [Description("The total price may not different due to promotion or discount")]
        public int TotalPrice { get; set; }

        [DisplayName("Order Memo")]
        [DataType(DataType.MultilineText)]
        public string Memo { get; set; }

        [DisplayName("Purchase Time")]
        public DateTime BuyOn { get; set; }

        public string DisplayName
        {
            get { return "User Name: " + this.Member.UserName + ", purchase time:" + this.BuyOn; }
        }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        

    }
}