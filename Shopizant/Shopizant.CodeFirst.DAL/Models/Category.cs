using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopizant.CodeFirst.DAL.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; } 
        /// <summary>
        /// Each catagory object should have the all the product details under a category
        /// Insitalized 
        /// </summary>
        public Category()
        {
           Products = new HashSet<Product>();
        }
        //collection of product
        public ICollection<Product> Products { get; set; }
    }
}
