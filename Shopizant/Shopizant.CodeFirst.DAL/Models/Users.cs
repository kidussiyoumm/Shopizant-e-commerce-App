using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopizant.CodeFirst.DAL.Models
{
    public class Users 
    {
        public Users()
        {
          //  Cart = new HashSet<Cart>();
        }
        [Key]
        
        public string EmailId { get; set; }

        [Required]
        [MinLength(3), MaxLength(25)]
        public string Password { get; set; }
        [Required]
        [MinLength(3), MaxLength(10)]
        public string Gender { get; set; }
        [Required]
        [MinLength(3), MaxLength(30)]
        public string Address {  get; set; }
        [ForeignKey("RoleId")]
        public byte RoleId { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Roles Role { get; set; }
        public ICollection<PurchaseDetails> PurchaseDetails { get; set; }
    }
}
