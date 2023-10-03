using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopizant.CodeFirst.DAL.Models
{
    public class Roles
    {
        [Key]
        public byte RoleID { get; set; }

        [Required]
        [MinLength(3), MaxLength(25)]
        public string RoleName { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}
