using Ecommerce.Areas.Customer.Models;
using Ecommerce.Areas.Customer.Repositories;
using Microsoft.AspNetCore.Identity; 

namespace Ecommerce.Areas.Customer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;
        private readonly PasswordHasher<CustomerModel> _passwordHasher;

        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;
            _passwordHasher = new PasswordHasher<CustomerModel>();
        }

        public void Register(CustomerModel customer)
        {
            customer.PasswordHash = _passwordHasher.HashPassword(customer, customer.PasswordHash);
            _repo.Add(customer);
        }

        public CustomerModel? Login(string email, string password)
        {
            var customer = _repo.GetCustomerByEmail(email);
            if (customer == null) return null;

            var result = _passwordHasher.VerifyHashedPassword(customer, customer.PasswordHash, password);

            return result == PasswordVerificationResult.Success ? customer : null;
        }

        public CustomerModel? GetById(int id)
        {
            return _repo.GetById(id);
        }

        public void Update(CustomerModel customer)
        {
            if (!string.IsNullOrEmpty(customer.PasswordHash))
            {
                customer.PasswordHash = _passwordHasher.HashPassword(customer, customer.PasswordHash);
            }
            _repo.Update(customer);
        }
    }
}
