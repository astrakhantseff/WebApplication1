using AutoMapper;
using WebApplication1.Controllers;
using WebApplication1.Models;
using WebApplication1.Models.Dto;

namespace WebApplication1
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMap()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<DoctorsDto, Doctor>();
                config.CreateMap<Doctor, DoctorsDto>();

                config.CreateMap<PatientsDto, Patient>();
                config.CreateMap<Patient, PatientsDto>();

                config.CreateMap<Doctor, GetDoctorByIdDto>();
                config.CreateMap<Patient, GetPatientByIdDto>();
            });
            return mappingConfig;
        }
    }
}
