using AutoMapper;
using Basket.Api.Entities;
using EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.Api.Mapping
{
	public class BasketProfile : Profile
	{
		public BasketProfile()
		{
			CreateMap<BasketCheckout, BasketCheckoutEvent>().ReverseMap();
		}
	}
}
