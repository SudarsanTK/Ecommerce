using System.Data;
using Dapper;
using Ecommerce.Areas.Admin.Models;

namespace Ecommerce.Areas.Admin.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _db;

        public ProductRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<ProductModel> GetAll()
        {
            string query = "SELECT * FROM Products";
            return _db.Query<ProductModel>(query);
        }

        public ProductModel? GetById(int id)
        {
            string query = "SELECT * FROM Products WHERE Id = @Id";
            return _db.QueryFirstOrDefault<ProductModel>(query, new { Id = id });
        }

        public int Add(ProductModel product)
        {
            string query = @"INSERT INTO Products 
                            (Name, Description, Price, Quantity, ImageUrl) 
                            VALUES (@Name, @Description, @Price, @Quantity, @ImageUrl); 
                            SELECT CAST(SCOPE_IDENTITY() as int);";

            return _db.Query<int>(query, product).Single();
        }

        public void Update(ProductModel product)
        {
            string query = @"UPDATE Products 
                             SET Name = @Name, Description = @Description, Price = @Price, 
                                 Quantity = @Quantity, ImageUrl = @ImageUrl 
                             WHERE Id = @Id";
            _db.Execute(query, product);
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM Products WHERE Id = @Id";
            _db.Execute(query, new { Id = id });
        }
    }
}
