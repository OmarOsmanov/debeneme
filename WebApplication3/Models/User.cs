using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(500),Required]
        public string Name { get; set; }
        [MaxLength(500),Required]
        public string Surname { get; set; }
        [MaxLength(500),Required]
        public string Phone { get; set; }
        [MaxLength(500),Required]
        public string Email { get; set; }

        public List<Blog> Blogs { get; set; }

    }
}
