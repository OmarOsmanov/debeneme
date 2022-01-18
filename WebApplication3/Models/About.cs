using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class About
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(500),Required]
        public string Title { get; set; }
        [MaxLength(500),Required]
        public string Subtitle { get; set; }

    }
}
