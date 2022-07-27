using MongoDB.Driver;
using ProductApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Infrastructure
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
