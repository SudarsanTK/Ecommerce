using Ecommerce.Areas.Admin.Models;

namespace Ecommerce.Areas.Admin.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<ProductModel> GetAll();
        ProductModel? GetById(int id);
        int Add(ProductModel product);
        void Update(ProductModel product);
        void Delete(int id);
    }
}
