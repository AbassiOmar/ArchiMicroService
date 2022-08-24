using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPAClient.Models;
using SPAClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPAClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(IEnumerable<ProductModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetProducts()
        {
            var products = await this.productService.GetProducts();
            return Ok(products);
        }
    }
}
