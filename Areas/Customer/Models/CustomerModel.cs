using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Areas.Customer.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string PasswordHash { get; set; }  

        [Required]
        public string? Name { get; set; }

        public string? Phone { get; set; }
    }
}
