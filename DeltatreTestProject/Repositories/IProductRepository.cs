using DeltatreTestProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltatreTestProject.Repositories
{
    interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        Product GetProduct(string name);

        void AddProduct(Product product);

        Object GetLastModifiedVersion(); //Leave as object, until versioning is buckled down. Could be anything from date to guid, based on database

    }
}
