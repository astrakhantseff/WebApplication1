using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Family { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SecondName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public bool Sex { get; set; }

        [ForeignKey("Region")]
        public int? RegionId { get; set; }
    }
}