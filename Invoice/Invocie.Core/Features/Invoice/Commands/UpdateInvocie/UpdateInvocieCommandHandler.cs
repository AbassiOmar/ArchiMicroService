using AutoMapper;
using Invocie.Core.Contratcs.Infra;
using Invocie.Core.Contratcs.Persistence;
using Invocie.Core.Exceptions;
using Invoice.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Invocie.Core.Features.Invoice.Commands.UpdateInvocie
{
    public class UpdateInvocieCommandHandler : IRequestHandler<UpdateInvocieCommand>
    {
        private readonly IInvoiceRepository invoiceRepository;
        private readonly IMapper mapper;
        private readonly ILogger<UpdateInvocieCommandHandler> logger;
        public UpdateInvocieCommandHandler(IInvoiceRepository invoiceRepository,
            IMapper mapper,
            IEmailService emailService,
            ILogger<UpdateInvocieCommandHandler> logger)
        {
            this.invoiceRepository = invoiceRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Unit> Handle(UpdateInvocieCommand request, CancellationToken cancellationToken)
        {
            var invoiceToUpdate = await this.invoiceRepository.GetByIdAsync(request.Id);
            if(invoiceToUpdate==null)
            {
                throw new NotFoundException(nameof(InvoiceData), request.Id);
            }
            mapper.Map(request, invoiceToUpdate, typeof(UpdateInvocieCommand), typeof(InvoiceData));
            await this.invoiceRepository.UpdateAsync(invoiceToUpdate);
            this.logger.LogInformation($"Invoice {invoiceToUpdate.Id} is successfully updated.");
            return Unit.Value;
        }
    }
}
