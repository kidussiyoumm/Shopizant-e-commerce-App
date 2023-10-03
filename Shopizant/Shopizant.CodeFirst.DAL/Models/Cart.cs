using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shopizant.CodeFirst.DAL.Models
{
    public class Cart
    {

        [Key]
        public string ProductId { get; set; }
        [Required]
        [MinLength(3), MaxLength(25)]
        public string ProductName { get; set; }
        [Required]
        
        public string EmailId { get; set; }
        [Required]
        [MinLength(1), MaxLength(25)]
        public byte Quantity { get; set; }

        public Users Email { get; set; }
        //public Product product { get; set; }
    }
}
