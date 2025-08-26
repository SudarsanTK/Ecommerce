using Ecommerce.Areas.Customer.Models;
using Ecommerce.Areas.Customer.Repositories;

namespace Ecommerce.Areas.Customer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;

        public OrderService(IOrderRepository repo)
        {
            _repo = repo;
        }

        public void PlaceOrder(OrderModel order)
        {
            order.OrderDate = DateTime.Now;

            _repo.AddOrder(order);

            _repo.DecreaseStock(order.ProductId, order.Quantity); 
        }

        public IEnumerable<OrderModel> GetOrders(int customerId)
        {
            return _repo.GetOrdersByCustomer(customerId);
        }
    }
}
