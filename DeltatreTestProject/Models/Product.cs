using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltatreTestProject.Models
{
    public class Product
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public int Quantity { get; set; } //TODO: Leave name generic, in case Quantity needs to become a more detailed sub-class
    }
}
