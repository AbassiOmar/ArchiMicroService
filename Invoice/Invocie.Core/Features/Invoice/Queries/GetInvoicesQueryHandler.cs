using AutoMapper;
using Invocie.Core.Contratcs.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Invocie.Core.Features.Invoice.Queries
{
    public class GetInvoicesQueryHandler : IRequestHandler<GetInvoicesQuery, List<InvoiceViewModel>>
    {
        private readonly IInvoiceRepository invoiceRepository;
        private readonly IMapper mapper;

        public GetInvoicesQueryHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            this.invoiceRepository = invoiceRepository ?? throw new ArgumentNullException(nameof(invoiceRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<InvoiceViewModel>> Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
        {
            var invoices = await this.invoiceRepository.GetInvoicesByUserName(request.UserName);
            return this.mapper.Map<List<InvoiceViewModel>>(invoices);
        }
    }
}
