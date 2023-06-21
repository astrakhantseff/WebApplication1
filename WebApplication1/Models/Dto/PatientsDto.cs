using System;

namespace WebApplication1.Models
{
    public class PatientsDto
    {
        public int Id { get; set; }
        public string Family { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Sex { get; set; }
        public int? RegionId { get; set; }
    }
}