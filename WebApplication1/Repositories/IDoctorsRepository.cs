using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Dto;

namespace WebApplication1.Repositories
{
    public interface IDoctorsRepository
    {
        Task<IEnumerable<GetDoctorsDto>> GetDoctors(int page, string sort);
        Task<GetDoctorByIdDto> GetDoctorById(int id);
        Task<DoctorsDto> UpdateDoctor(DoctorsDto doctorDto);
        Task<DoctorsDto> CreateDoctor(DoctorsDto doctorDto);
        Task<bool> DeleteDoctor(int id);
    }
}
