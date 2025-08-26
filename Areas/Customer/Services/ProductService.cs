using Ecommerce.Areas.Admin.Models;
using Ecommerce.Areas.Customer.Repositories;
using System.Collections.Generic;

namespace Ecommerce.Areas.Customer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<ProductModel> GetAllProducts()
        {
            return _repo.GetAllProducts();
        }

        public ProductModel? GetProductById(int id)
        {
            return _repo.GetProductById(id);
        }
    }
}
