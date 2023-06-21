using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Specialty
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NameOfSpecialty { get; set; }
    }
}