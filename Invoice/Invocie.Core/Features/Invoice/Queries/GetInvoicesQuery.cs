using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invocie.Core.Features.Invoice.Queries
{
    public class GetInvoicesQuery: IRequest<List<InvoiceViewModel>>
    {
        public string UserName { get; set; }

        public GetInvoicesQuery(string userName)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
        }
    }
}
