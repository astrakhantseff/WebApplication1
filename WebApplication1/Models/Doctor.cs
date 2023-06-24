using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [ForeignKey("Cabinet")]
        [Required]
        public int CabinetId { get; set; }

        [ForeignKey("Specialty")]
        [Required]
        public int SpecialtyId { get; set; }

        [ForeignKey("Region")]
        public int? RegionId { get; set; }
    }
}
