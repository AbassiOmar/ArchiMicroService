using Basket.Api.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.Api.Repositories
{
    public class BasketRepository: IBasketRepository
    {
        private readonly IDistributedCache distributedcache;
        public BasketRepository(IDistributedCache distributedcache)
        {
            this.distributedcache = distributedcache?? throw new ArgumentNullException(nameof(distributedcache));

        }

        public async Task DeleteBasket(string userName)
        {
            await distributedcache.RemoveAsync(userName);
        }

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            var basket = await distributedcache.GetStringAsync(userName);
            if (string.IsNullOrEmpty(basket))
                return null;
            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            await distributedcache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));

            return await GetBasket(basket.UserName);
        }
    }
}
