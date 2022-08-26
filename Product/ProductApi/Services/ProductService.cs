using ProductApi.Entities;
using ProductApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }
        public async Task  CreateProduct(Product product)
        {
            await this.productRepository.CreateProduct(product);
        }

        public async Task <bool> DeleteProduct(string id)
        {
            return await this.productRepository.DeleteProduct(id);
        }

        public async Task <Product> GetProduct(string id)
        {
           
            return await this.productRepository.GetProduct(id);
        }

        public async Task <IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            return await this.productRepository.GetProductByCategory(categoryName);
        }

        public async Task <IEnumerable<Product>> GetProductByName(string name)
        {
            return await this.productRepository.GetProductByName(name);
        }

        public async Task <IEnumerable<Product>> GetProducts()
        {
            return await this.productRepository.GetProducts();
        }

        public async Task <bool> UpdateProduct(Product product)
        {
            return await this.productRepository.UpdateProduct(product);
        }
    }
}
