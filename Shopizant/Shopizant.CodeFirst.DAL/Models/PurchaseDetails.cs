using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopizant.CodeFirst.DAL.Models
{
    public class PurchaseDetails
    {
        [Key]
        public int PurchaseID { get; set; }

        [Required]
        [MinLength(3), MaxLength(25)]
        public string PurchaseName { get; set; }

        [Required]
        [MinLength(8), MaxLength(25)]
        public string Email { get; set; }

        [Range(minimum: 0, maximum: int.MaxValue)]
        public int QuantityPurchased { get; set; }
        public DateTime DayOfPurchase { get; set; }
        public Users UserEmail { get; set; }
        public Product ProductNav { get; set; }



    }
}
