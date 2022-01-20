using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CarAppDotNetApi.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Model
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public virtual IEnumerable<Car> Cars { get; set; }
    }
}