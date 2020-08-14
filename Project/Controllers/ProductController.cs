using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Product.Contracts.Interfaces.Repositories;
using Product.Contracts.Models;

namespace Product.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IEnumerable<Item> ItemsByName()
        {
            return this._productRepository.GetProductItem();
        }

        [HttpDelete]
        public IActionResult Category(string name)
        {
            this._productRepository.DeleteCategory(name);
            return Ok();
        }
    }
}
