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
    public class DoctorsRepository : IDoctorsRepository
    {
        private const int _pageSize = 10;

        private readonly ApplicationDbContext _db;

        private readonly IMapper _mapper;

        public DoctorsRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetDoctorsDto>> GetDoctors(int page, string sort)
        {
            List<Doctor> doctors = page > 0
                ? await _db.Doctors
                    .Skip((page - 1) * _pageSize)
                    .Take(_pageSize)
                    .ToListAsync()
                : await _db.Doctors
                    .ToListAsync();

            IEnumerable<GetDoctorsDto> result = from doctor in doctors
                   join region in _db.Regions on doctor.RegionId equals region.Id
                   join specialty in _db.Specialties on doctor.SpecialtyId equals specialty.Id
                   join cabinet in _db.Cabinets on doctor.CabinetId equals cabinet.Id
                   select new GetDoctorsDto()
                   {
                       FullName = doctor.FullName,
                       NumberOfRegion = region.NumberOfRegion,
                       NameOfSpecialty = specialty.NameOfSpecialty,
                       NumberOfCab = cabinet.NumberOfCab
                   };

            return result.Sort(sort);
        }

        public async Task<GetDoctorByIdDto> GetDoctorById(int id)
        {
            Doctor doctor = await _db.Doctors
                .Where(doctor => doctor.Id == id)
                .FirstOrDefaultAsync();
            return _mapper.Map<GetDoctorByIdDto>(doctor);
        }

        public async Task<DoctorsDto> CreateDoctor(DoctorsDto doctorDto)
        {
            Doctor doctor = _mapper.Map<DoctorsDto, Doctor>(doctorDto);

            if (doctor.Id <= 0)
            {
                _db.Doctors.Add(doctor);
                await _db.SaveChangesAsync();
            }

            return _mapper.Map<Doctor, DoctorsDto>(doctor);
        }

        public async Task<DoctorsDto> UpdateDoctor(DoctorsDto doctorDto)
        {
            Doctor doctor = _mapper.Map<DoctorsDto, Doctor>(doctorDto);

            if (doctor.Id > 0)
            {
                _db.Doctors.Update(doctor);
                await _db.SaveChangesAsync();
            }

            return _mapper.Map<Doctor, DoctorsDto>(doctor);
        }

        public async Task<bool> DeleteDoctor(int id)
        {
            try
            {
                Doctor doctor = await _db.Doctors.FirstOrDefaultAsync(doctor => doctor.Id == id);
                if (doctor == null)
                {
                    return false;
                }

                _db.Doctors.Remove(doctor);
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
