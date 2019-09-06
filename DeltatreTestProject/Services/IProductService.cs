using DeltatreTestProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltatreTestProject.Services
{
    interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        void AddProduct(Product product);

        string GetModifiedVersion();
    }
}
