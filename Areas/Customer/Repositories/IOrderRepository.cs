using Ecommerce.Areas.Customer.Models;

namespace Ecommerce.Areas.Customer.Repositories
{
    public interface IOrderRepository
    {
        void AddOrder(OrderModel order);

        void DecreaseStock(int productId, int amount);
        IEnumerable<OrderModel> GetOrdersByCustomer(int customerId);
    }
}
