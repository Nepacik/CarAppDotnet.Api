using System.ComponentModel.DataAnnotations;

namespace CarAppDotNetApi.Models
{
    public class Car
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public virtual Model Model { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}