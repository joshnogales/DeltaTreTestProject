using System;
using System.Collections.Generic;
using System.Linq;
using DeltatreTestProject.Models;
using DeltatreTestProject.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeltatreTestProject.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductCatalogController : ControllerBase
    {
        IProductService _productService;

        public ProductCatalogController()
        {
            _productService = new ProductService(); //TODO: Replace with DI
        }


        [HttpGet]
        [Route("")]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts().ToList();
            var version = _productService.GetModifiedVersion();

            return Ok(new ProductsListDto { Products = products, ModifiedVersion = version});
        }

        [HttpGet]
        [Route("status/version")]
        public IActionResult GetModifiedVersion()
        {
            var retVal = _productService.GetModifiedVersion();
            return Ok(retVal);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody]Product product)
        {
            if (String.IsNullOrWhiteSpace(product.Name) || product.Quantity < 0)
                return BadRequest();

            try
            {
                _productService.AddProduct(product);
            }
            catch(InvalidOperationException e)
            {
                return Conflict(e.Message);
            }

            return Ok();
        }

    }
}
