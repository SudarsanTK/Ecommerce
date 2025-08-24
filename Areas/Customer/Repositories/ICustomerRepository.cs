using Ecommerce.Areas.Customer.Models;

namespace Ecommerce.Areas.Customer.Repositories
{
    public interface ICustomerRepository
    {
        void Add(CustomerModel customer);
        CustomerModel? GetCustomerByEmail(string email);
        CustomerModel? GetById(int id);
        void Update(CustomerModel customer);
    }
}
