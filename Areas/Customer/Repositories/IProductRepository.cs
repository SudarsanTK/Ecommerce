using Ecommerce.Areas.Admin.Models;
using System.Collections.Generic;

namespace Ecommerce.Areas.Customer.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<ProductModel> GetAllProducts();
        ProductModel? GetProductById(int id);
    }
}
