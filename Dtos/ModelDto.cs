using System.ComponentModel.DataAnnotations;

namespace CarAppDotNetApi.Dtos
{
    public class ModelDto
    {
        [Required]
        public string Name { get; set; }
    }
}