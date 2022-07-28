using AutoMapper;
using Invocie.Core.Contratcs.Infra;
using Invocie.Core.Contratcs.Persistence;
using Invoice.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Invocie.Core.Features.Invoice.Commands.CheckoutInvocie
{
    public class CheckoutInvoiceCommandHandler : IRequestHandler<CheckoutInvoiceCommand, int>
    {
        private readonly IInvoiceRepository invoiceRepository;
        private readonly IMapper mapper;
        private readonly IEmailService emailService;
        private readonly ILogger<CheckoutInvoiceCommandHandler> logger;
        public CheckoutInvoiceCommandHandler(IInvoiceRepository invoiceRepository,
            IMapper mapper,
            IEmailService emailService,
            ILogger<CheckoutInvoiceCommandHandler> logger)
        {
            this.invoiceRepository = invoiceRepository;
            this.mapper = mapper;
            this.emailService = emailService;
            this.logger=logger;
        }
        public async Task<int> Handle(CheckoutInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoiceEntity = this.mapper.Map<InvoiceData>(request);
            var newInvoice = await this.invoiceRepository.AddAsync(invoiceEntity);
            this.logger.LogInformation($"invoice {newInvoice.Id} is successfully created.");
            return newInvoice.Id;

        }
    }
}
