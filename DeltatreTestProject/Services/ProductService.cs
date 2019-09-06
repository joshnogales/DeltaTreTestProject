using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeltatreTestProject.Models;
using DeltatreTestProject.Repositories;

namespace DeltatreTestProject.Services
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepo;

        public ProductService()
        {
            _productRepo = new ProductInMemoryRepository(); //TODO: Repalce with real repository and use DI.
        }

        public void AddProduct(Product product)
        {
            
            var existingProduct = _productRepo.GetProduct(product.Name);

            if (existingProduct == null)
                _productRepo.AddProduct(product);
            else
                throw new InvalidOperationException("Product already exists.");

        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepo.GetAllProducts();
        }

        public string GetModifiedVersion()
        {
            return _productRepo.GetLastModifiedVersion().ToString();
        }
    }
}
