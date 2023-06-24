using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Dto;

namespace WebApplication1.Repositories
{
    public interface IPatientsRepository
    {
        Task<IEnumerable<GetPatientsDto>> GetPatients(int page, string sort);
        Task<GetPatientByIdDto> GetPatientById(int id);
        Task<PatientsDto> UpdatePatient(PatientsDto doctorDto);
        Task<PatientsDto> CreatePatient(PatientsDto doctorDto);
        Task<bool> DeletePatient(int id);
    }
}