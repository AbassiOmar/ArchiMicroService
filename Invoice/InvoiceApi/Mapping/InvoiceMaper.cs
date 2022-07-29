using AutoMapper;
using EventBus.Events;
using Invocie.Core.Features.Invoice.Commands.CheckoutInvocie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceApi.Mapping
{
    public class InvoiceProfile:Profile
    {
        public InvoiceProfile()
        {
            CreateMap<CheckoutInvoiceCommand, BasketCheckoutEvent>().ReverseMap();
        }
    }
}
