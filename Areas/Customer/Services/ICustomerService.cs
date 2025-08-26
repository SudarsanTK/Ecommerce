using Ecommerce.Areas.Customer.Models;

namespace Ecommerce.Areas.Customer.Services
{
    public interface ICustomerService
    {
        void Register(CustomerModel customer);
        CustomerModel? Login(string email, string password);
        CustomerModel? GetById(int id);
        void Update(CustomerModel customer);
    }
}
