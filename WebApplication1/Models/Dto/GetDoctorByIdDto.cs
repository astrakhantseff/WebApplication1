using System;

namespace WebApplication1.Models.Dto
{
    public class GetDoctorByIdDto
    {
        public string Family { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Sex { get; set; }
        public int? NumberOfRegion { get; set; }
    }
}
