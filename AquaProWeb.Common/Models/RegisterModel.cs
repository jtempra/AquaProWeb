using System.ComponentModel.DataAnnotations;

namespace AquaProWeb.Common.Models
{
    public class RegisterModel
    {
        [Required]
        public string? Name { get; set; }
        [Required, DataType(DataType.EmailAddress), EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Role { get; set; }
        [Required, DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required, Compare("Password"), DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
    }
}
