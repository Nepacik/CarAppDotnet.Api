using System.ComponentModel.DataAnnotations;

namespace CarAppDotNetApi.Dtos
{
    public class CarDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ModelName { get; set; }
        [Required]
        public string Name { get; set; }
    }
}