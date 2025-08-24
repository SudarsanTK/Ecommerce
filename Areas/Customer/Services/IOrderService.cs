using Ecommerce.Areas.Customer.Models;

namespace Ecommerce.Areas.Customer.Services
{
    public interface IOrderService
    {
        void PlaceOrder(OrderModel order);
        IEnumerable<OrderModel> GetOrders(int customerId);
    }
}
