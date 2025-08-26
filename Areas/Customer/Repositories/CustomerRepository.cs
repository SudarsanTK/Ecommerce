using Dapper;
using Ecommerce.Areas.Customer.Models;
using System.Data;

namespace Ecommerce.Areas.Customer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbConnection _db;

        public CustomerRepository(IDbConnection db)
        {
            _db = db;
        }

        public void Add(CustomerModel customer)
        {
            string sql = @"INSERT INTO Customers (Email, PasswordHash, Name, Phone)
                           VALUES (@Email, @PasswordHash, @Name, @Phone)";
            _db.Execute(sql, customer);
        }

        public CustomerModel? GetCustomerByEmail(string email)
        {
            string sql = "SELECT * FROM Customers WHERE Email = @Email";
            return _db.QueryFirstOrDefault<CustomerModel>(sql, new { Email = email });
        }

        public CustomerModel? GetById(int id)
        {
            string sql = "SELECT * FROM Customers WHERE Id = @Id";
            return _db.QueryFirstOrDefault<CustomerModel>(sql, new { Id = id });
        }

        public void Update(CustomerModel customer)
        {
            string sql = @"UPDATE Customers 
                           SET Name = @Name, Phone = @Phone 
                           WHERE Id = @Id";
            _db.Execute(sql, customer);
        }
    }
}
