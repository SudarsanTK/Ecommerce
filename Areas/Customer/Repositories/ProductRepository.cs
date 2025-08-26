using Dapper;
using Ecommerce.Areas.Admin.Models;
using System.Data;
using System.Linq;

namespace Ecommerce.Areas.Customer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _db;

        public ProductRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<ProductModel> GetAllProducts()
        {
            string query = "SELECT * FROM Products";
            return _db.Query<ProductModel>(query).ToList();
        }

        public ProductModel? GetProductById(int id)
        {
            string query = "SELECT * FROM Products WHERE Id=@Id";
            return _db.Query<ProductModel>(query, new { Id = id }).FirstOrDefault();
        }
    }
}
