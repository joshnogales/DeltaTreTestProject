using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeltatreTestProject.Models;

namespace DeltatreTestProject.Repositories
{
    public class ProductInMemoryRepository : IProductRepository
    {
        private static Dictionary<string, Product> _productMockDb = new Dictionary<string, Product>();

        public void AddProduct(Product product)
        {
            if (_productMockDb.ContainsKey(product.Name))
                throw new InvalidOperationException("Unique key requirement on 'Name'");

            _productMockDb.Add(product.Name, product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productMockDb.Values.ToList();//.OrderBy(x => x.Name);
        }

        public Product GetProduct(string name)
        {
            Product retVal;

            _productMockDb.TryGetValue(name, out retVal);

            return retVal;
        }

        public Object GetLastModifiedVersion()
        {
            return _productMockDb.Count; //Could be date of last modified item, in full db. For mock, will just use count.
        }
    }
}
