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
        private readonly ApplicationDbContext _db;

        private readonly IMapper _mapper;

        public DoctorsRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DoctorsDto>> GetDoctors()
        {
            List<Doctor> doctors = await _db.Doctors.ToListAsync();
            return _mapper.Map<List<DoctorsDto>>(doctors);
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

        public async Task<IEnumerable<Cabinet>> GetCabinets()
        {
            return await _db.Cabinets.ToListAsync();
        }

        public async Task<IEnumerable<Region>> GetRegions()
        {
            return await _db.Regions.ToListAsync();
        }

        public async Task<IEnumerable<Specialty>> GetSpecialties()
        {
            return await _db.Specialties.ToListAsync();
        }
    }
}
