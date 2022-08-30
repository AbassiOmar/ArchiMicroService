using Microsoft.Extensions.Logging;
using SPAClient.Extensions;
using SPAClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SPAClient.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient client;
        public BasketService(HttpClient client, ILogger<ProductService> logger)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task CheckoutBasket(BasketCheckoutModel model)
        {
            var response = await this.client.PostAsJson($"/Basket/Checkout", model);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }

        public async Task<BasketModel> GetBasket(string userName)
        {
            var response = await this.client.GetAsync($"/Basket/{userName}");
            return await response.ReadContentAs<BasketModel>();
        }

        public async Task<BasketModel> UpdateBasket(BasketModel basket)
        {
            var response = await this.client.PostAsJson($"/Basket", basket);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<BasketModel>();
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }
    }
}
