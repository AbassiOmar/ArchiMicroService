using Invocie.Core.Contratcs.Persistence;
using Invoice.Domain.Entities;
using Invoice.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Infrastructure.Repositories
{
    public class InvoiceRepository : BaseRepository<InvoiceData>, IInvoiceRepository
    {
        public InvoiceRepository(InvoiceContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<InvoiceData>> GetInvoicesByUserName(string userName)
        {
            var orderList = await _dbContext.Invoices
                                .Where(o => o.UserName == userName)
                                .ToListAsync();
            return orderList;
        }
    }
}
