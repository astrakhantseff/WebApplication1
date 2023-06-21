using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Cabinet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NumberOfCab { get; set; }
    }
}
