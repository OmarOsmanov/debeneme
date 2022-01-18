using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(500),Required]
        public string Name { get; set; }
        [MaxLength(500), Required]
        public string Title { get; set; }
        [MaxLength(500),Required]
        public string Discript { get; set; }
        [MaxLength(500)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
