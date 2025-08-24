using Dapper;
using Ecommerce.Areas.Customer.Models;
using System.Data;

namespace Ecommerce.Areas.Customer.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbConnection _db;

        public OrderRepository(IDbConnection db)
        {
            _db = db;
        }

        public void AddOrder(OrderModel order)
        {
            string query = @"INSERT INTO Orders (CustomerId, ProductId, Quantity, TotalPrice, OrderDate) 
                             VALUES (@CustomerId, @ProductId, @Quantity, @TotalPrice, @OrderDate)";
            _db.Execute(query, order);
        }

        public void DecreaseStock(int productId, int amount)
        {
            string query = @"UPDATE Products 
                     SET Quantity = Quantity - @Amount 
                     WHERE Id = @Id AND Quantity >= @Amount";
            _db.Execute(query, new { Id = productId, Amount = amount });
        }


        public IEnumerable<OrderModel> GetOrdersByCustomer(int customerId)
        {
            string query = "SELECT * FROM Orders WHERE CustomerId = @customerId";
            return _db.Query<OrderModel>(query, new { customerId });
        }
    }
}
