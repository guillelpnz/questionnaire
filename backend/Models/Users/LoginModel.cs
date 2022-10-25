using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

namespace WebApi.Models.Users
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
