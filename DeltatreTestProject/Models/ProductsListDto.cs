using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltatreTestProject.Models
{
    public class ProductsListDto
    {
        public List<Product> Products { get; set; }

        public string ModifiedVersion { get; set; }
    }
}
