using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Invoice.Domain.Entities;
namespace Invocie.Core.Contratcs.Persistence
{
    public interface IInvoiceRepository:IAsyncRepository<InvoiceData>
    {
        Task<IEnumerable<InvoiceData>> GetInvoicesByUserName(string userName);
    }
}
