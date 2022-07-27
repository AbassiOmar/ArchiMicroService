using Basket.Api.Entities;
using Basket.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.Api.Services
{
    public class BasketService: IBasketService
    {
        private readonly IBasketRepository basketRepository;
        public BasketService(IBasketRepository basketRepository)
        {
            this.basketRepository = basketRepository;
        }

        public async  Task DeleteBasket(string userName)
        {
             await this.basketRepository.DeleteBasket(userName);
        }

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            return await this.basketRepository.GetBasket(userName);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            return await this.basketRepository.UpdateBasket(basket);
        }
    }
}
