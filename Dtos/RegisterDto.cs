using System.ComponentModel.DataAnnotations;

namespace CarAppDotNetApi.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "PASSWORD_TOO_SHORT")]
        public string Password { get; set; }
    }
}