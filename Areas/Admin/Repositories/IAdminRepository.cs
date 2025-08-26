using Ecommerce.Areas.Admin.Models;

namespace Ecommerce.Areas.Admin.Repositories
{
    public interface IAdminRepository
    {
        AdminModel GetAdminByUsername(string username);
    }
}