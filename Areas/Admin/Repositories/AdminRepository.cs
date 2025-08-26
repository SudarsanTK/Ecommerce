using Dapper;
using Microsoft.Data.SqlClient;
using Ecommerce.Areas.Admin.Models;
using System.Data;

namespace Ecommerce.Areas.Admin.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly string _connectionString;

        public AdminRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);

        public AdminModel GetAdminByUsername(string username)
        {
            using var db = Connection;
            string sql = "SELECT * FROM Admins WHERE Username = @Username";
            return db.QueryFirstOrDefault<AdminModel>(sql, new { Username = username });
        }
    }
}