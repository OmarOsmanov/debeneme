using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.ViewModels
{
    public class VmHome
    {
        public Setting setting { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
