using System;

namespace WebApplication1.Models.Dto
{
    public class GetDoctorByIdDto
    {
        public string FullName { get; set; }
        public int CabinetId { get; set; }
        public int SpecialtyId { get; set; }
        public int? RegionId { get; set; }
    }
}
