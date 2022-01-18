using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Setting
    {
        [Key]

        public int Id { get; set; }
        [MaxLength(500),Required]
        public string Title { get; set; }
        [MaxLength(500),Required]
        public string EndTitle { get; set; }
        [MaxLength(50),Required]
        public string Logo { get; set; }


    }
}
