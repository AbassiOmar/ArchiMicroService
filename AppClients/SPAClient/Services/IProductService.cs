using SPAClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPAClient.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetProducts();
    }
}
