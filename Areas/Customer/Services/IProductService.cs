using Ecommerce.Areas.Admin.Models;
using System.Collections.Generic;

namespace Ecommerce.Areas.Customer.Services
{
    public interface IProductService
    {
        IEnumerable<ProductModel> GetAllProducts();
        ProductModel? GetProductById(int id);
    }
}
