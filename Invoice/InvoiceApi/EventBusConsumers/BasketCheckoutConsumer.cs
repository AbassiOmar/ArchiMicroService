using AutoMapper;
using EventBus.Events;
using Invocie.Core.Features.Invoice.Commands.CheckoutInvocie;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceApi.EventBusConsumers
{
    public class BasketCheckoutConsumer : IConsumer<BasketCheckoutEvent>
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly ILogger<BasketCheckoutConsumer> logger;

        public BasketCheckoutConsumer(IMediator mediator,
            IMapper mapper,
            ILogger<BasketCheckoutConsumer> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
            this.mapper = mapper;
        }
        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            try
            {
                var command = this.mapper.Map<CheckoutInvoiceCommand>(context.Message);
                var result = await this.mediator.Send(command);

                this.logger.LogInformation("BasketCheckoutEvent consumed successfully. Created Order Id : {newOrderId}", result);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
