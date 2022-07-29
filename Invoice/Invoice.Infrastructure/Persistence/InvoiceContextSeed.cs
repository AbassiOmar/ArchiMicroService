using Invoice.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Infrastructure.Persistence
{
    public class InvoiceContextSeed
    {
        public static async Task SeedAsync(InvoiceContext orderContext, ILogger<InvoiceContextSeed> logger)
        {
            if (!orderContext.Invoices.Any())
            {
                orderContext.Invoices.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(InvoiceContext).Name);
            }
        }

        private static IEnumerable<InvoiceData> GetPreconfiguredOrders()
        {
            return new List<InvoiceData>
            {
                new InvoiceData() {UserName = "abbassi", FirstName = "omar", LastName = "abbassi", EmailAddress = "omar@gmail.com", AddressLine = "cergy", Country = "France", TotalPrice = 100 }
            };
        }
    }
}
