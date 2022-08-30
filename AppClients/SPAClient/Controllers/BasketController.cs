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
    public class BasketController : ControllerBase
    {
        private readonly IBasketService basketService;
        public BasketController(IBasketService basketService)
        {
            this.basketService = basketService;
        }

        [HttpGet("GetBusketByUserName")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BasketModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<BasketModel>> GetBusketByUserName(string userName)
        {
            var basket = await this.basketService.GetBasket(userName);
            return Ok(basket);
        }

        [HttpPost]
        [ProducesResponseType(typeof(BasketModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<BasketModel>> UpdateBasket([FromBody] BasketModel basket)
        {
            return Ok(await this.basketService.UpdateBasket(basket));
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Checkout([FromBody] BasketCheckoutModel basketCheckout)
        {
          
            return Ok(this.basketService.CheckoutBasket(basketCheckout));
        }
    }
}
