using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CarAppDotNetApi.Models
{
    [Index(nameof(Username), IsUnique = true)]
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
        
    }
}