using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DbContexts;
using WebApplication1.Models;
using WebApplication1.Models.Dto;

namespace WebApplication1.Repositories
{
    public class PatientsRepository : IPatientsRepository
    {
        private const int _pageSize = 10;

        private readonly ApplicationDbContext _db;

        private readonly IMapper _mapper;

        public PatientsRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetPatientsDto>> GetPatients(int page, string sort)
        {
            List<Patient> patients = page > 0
                ? await _db.Patients
                    .Skip((page - 1) * _pageSize)
                    .Take(_pageSize)
                    .ToListAsync()
                : await _db.Patients
                    .ToListAsync();

            IEnumerable<GetPatientsDto> result = from patient in patients
                   join region in _db.Regions on patient.RegionId equals region.Id
                   select new GetPatientsDto()
                   {
                       Family = patient.Family,
                       FirstName = patient.FirstName,
                       SecondName = patient.SecondName,
                       Address = patient.Address,
                       DateOfBirth = patient.DateOfBirth,
                       Sex = patient.Sex,
                       NumberOfRegion = region.NumberOfRegion
                   };

            return result.Sort(sort);
        }

        public async Task<GetPatientByIdDto> GetPatientById(int id)
        {
            Patient patient = await _db.Patients
                .Where(patient => patient.Id == id)
                .FirstOrDefaultAsync();
            return _mapper.Map<GetPatientByIdDto>(patient);
        }

        public async Task<PatientsDto> CreatePatient(PatientsDto patientsDto)
        {
            Patient patient = _mapper.Map<PatientsDto, Patient>(patientsDto);

            if (patient.Id <= 0)
            {
                _db.Patients.Add(patient);
                await _db.SaveChangesAsync();
            }

            return _mapper.Map<Patient, PatientsDto>(patient);
        }

        public async Task<PatientsDto> UpdatePatient(PatientsDto patientsDto)
        {
            Patient patient = _mapper.Map<PatientsDto, Patient>(patientsDto);

            if (patient.Id > 0)
            {
                _db.Patients.Update(patient);
                await _db.SaveChangesAsync();
            }

            return _mapper.Map<Patient, PatientsDto>(patient);
        }

        public async Task<bool> DeletePatient(int id)
        {
            try
            {
                Patient patient = await _db.Patients.FirstOrDefaultAsync(patient => patient.Id == id);
                if (patient == null)
                {
                    return false;
                }

                _db.Patients.Remove(patient);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}