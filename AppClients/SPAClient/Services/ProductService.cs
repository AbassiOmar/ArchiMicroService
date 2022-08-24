using Microsoft.Extensions.Logging;
using SPAClient.Extensions;
using SPAClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SPAClient.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        public ProductService(HttpClient client, ILogger<ProductService> logger)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ProductModel>> GetProducts()
        {
            var response = await _client.GetAsync("/Product");
            return  await response.ReadContentAs<List<ProductModel>>();
        }
    }
}
