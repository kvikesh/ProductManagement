using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Product.Contracts.Interfaces.Repositories;
using Product.Contracts.Interfaces.Services;
using Product.Contracts.Models;
using Product.Contracts.Models.Response;

namespace Product.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// API to get item list by item name
        /// </summary>
        /// <param name="name">item name</param>
        /// <returns>Item List as ItemResponse.</returns>

        [HttpGet]
        [Route("ItemsByName")]
        public List<ItemResponse> ItemsByName(string name)
        {
            return this._productService.GetItemsByName(name);
        }

        /// <summary>
        /// API to delete Category by passing Category name
        /// </summary>
        /// <param name="name">Category name</param>
        /// <returns>Ackowledgement</returns>

        [HttpDelete]
        [Route("Category")]
        public IActionResult Category(string name)
        {
            this._productService.DeleteCategory(name);
            return Ok();
        }
    }
}
