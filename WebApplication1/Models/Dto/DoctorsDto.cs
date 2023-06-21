namespace WebApplication1.Models
{
    public class DoctorsDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int CabinetId { get; set; }
        public int SpecialtyId { get; set; }
        public int? RegionId { get; set; }
    }
}
