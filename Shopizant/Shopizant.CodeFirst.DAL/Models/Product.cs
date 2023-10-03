using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopizant.CodeFirst.DAL.Models
{
    public class Product
    {
        [Key]
        public string ProductId { get; set; }

        [Required]
        [MinLength(3), MaxLength(25)]//lenght of the varchar 

        public string ProductName { get; set; }
        //[Column(TypeName = "Numeric(10,2")]//Changing column datatype
        public decimal Price { get; set; }

        [Range(minimum:0, maximum:int.MaxValue)]//setting lenght 
        public int QuantityAvailable { get; set; }
        [ForeignKey("CategoryId")]
        public byte CatrgoryId { get; set; }   //hold only the categoryId from the product
        

        public Category Category { get; set; } //hold all the category details , Forgein key
        public ICollection<PurchaseDetails> PurchaseDetails { get; set; } 

    }
}
