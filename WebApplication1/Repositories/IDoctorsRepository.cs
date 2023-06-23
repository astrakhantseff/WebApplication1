using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Dto;

namespace WebApplication1.Repositories
{
    public interface IDoctorsRepository
    {
        Task<IEnumerable<DoctorsDto>> GetDoctors(int page);
        Task<GetDoctorByIdDto> GetDoctorById(int id);
        Task<DoctorsDto> UpdateDoctor(DoctorsDto doctorDto);
        Task<DoctorsDto> CreateDoctor(DoctorsDto doctorDto);
        Task<bool> DeleteDoctor(int id);

        Task<IEnumerable<Cabinet>> GetCabinets();
        Task<IEnumerable<Region>> GetRegions();
        Task<IEnumerable<Specialty>> GetSpecialties();
    }
}
