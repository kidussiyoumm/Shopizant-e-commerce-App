using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shopizant.CodeFirst.DAL.Models
{
    public class CartItems
    {
        
        [Key]
        public string ProductId { get; set; }

        [Required]
        [MinLength(3), MaxLength(25)]
        public string ProductName { get; set; }

        [Required]
        [Range(minimum: 0, maximum: int.MaxValue)]
        public decimal price { get; set; }

        [Range(minimum: 0, maximum: int.MaxValue)]
        public int QuantityAvailable { get; set; }

        [Range(minimum: 0, maximum: int.MaxValue)]
        public int Qunatity { get; set; }

    }
}
