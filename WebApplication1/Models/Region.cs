using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Region
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NumberOfRegion { get; set; }
    }
}
