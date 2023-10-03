using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopizant.CodeFirst.DAL.Models
{
    public class CardDetails
    {
        [Key]
        public string NameCard { get; set; }
        [Required]
        [MinLength(3), MaxLength(25)]
        public string CardType { get; set; }
        [Required]
        [MinLength(3), MaxLength(25)]
        public decimal CardNumber { get; set; }
        public DateTime ExpDate { get; set; }
        [Required]
        [MinLength(3)]
        public decimal Cvv { get; set; }

        [Range(minimum: 0, maximum: int.MaxValue)]
        public decimal CardBalance { get; set; }



    }
}
