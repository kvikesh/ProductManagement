using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Product.Contracts.Interfaces.Services;
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
        /// <param name="name">item name, Page, RecordZie to fetch</param>
        /// <returns>Item List as ItemResponse.</returns>

        [HttpGet]
        [Route("ItemsByName")]
        public List<ItemResponse> ItemsByName(string name, int page=1, int recordSize=10)
        {
            if (page == 0) {
                page = 1;
            }
            if (recordSize == 0)
            {
                recordSize = 10;
            }
            return this._productService.GetItemsByName(name, page, recordSize);
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
            var result = this._productService.DeleteCategory(name);

            if (result == "ItemNotFound")
            {
                return NotFound();
            }
            else {
                return Ok();
            }
        }
    }
}
