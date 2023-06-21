using System;

namespace WebApplication1.Models.Dto
{
    public class GetPatientsDto
    {
        public string Family { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Sex { get; set; }
        public string NumberOfRegion { get; set; }
    }
}
