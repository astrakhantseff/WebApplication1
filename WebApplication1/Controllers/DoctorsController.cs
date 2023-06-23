using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Dto;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsRepository _repository;

        private readonly ResponseDto _response;

        public DoctorsController(IDoctorsRepository repository)
        {
            _repository = repository;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<IEnumerable<GetDoctorsDto>> Get([FromQuery]string sort, [FromQuery] int page)
        {
            try
            {
                IEnumerable<DoctorsDto> doctors = await _repository.GetDoctors(page);

                IEnumerable<Cabinet> cabinets = await _repository.GetCabinets();
                IEnumerable<Region> regions = await _repository.GetRegions();
                IEnumerable<Specialty> specialties = await _repository.GetSpecialties();

                IEnumerable<GetDoctorsDto> result = from doctor in doctors
                                                    join cabinet in cabinets on doctor.CabinetId equals cabinet.Id
                                                    join region in regions on doctor.RegionId equals region.Id
                                                    join specialty in specialties on doctor.SpecialtyId equals specialty.Id
                                                    select new GetDoctorsDto()
                                                    {
                                                        FullName = doctor.FullName,
                                                        NumberOfCab = cabinet.NumberOfCab,
                                                        NumberOfRegion = region.NumberOfRegion,
                                                        NameOfSpecialty = specialty.NameOfSpecialty
                                                    };
                
                return result.Sort(sort);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = e.Message;
                return null;
            }
        }

        [HttpGet("{id}")]
        public async Task<GetDoctorByIdDto> GetById(int id)
        {
            try
            {
                return await _repository.GetDoctorById(id);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = e.Message;
                return null;
            }
        }

        [HttpPost]
        public async Task<ResponseDto> Post([FromBody] DoctorsDto doctorDto)
        {
            try
            {
                _response.Result = await _repository.CreateDoctor(doctorDto);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = e.Message;
            }
            return _response;
        }

        [HttpPut("{id}")]
        public async Task<ResponseDto> Put(int id, [FromBody] DoctorsDto doctorDto)
        {
            try
            {
                _response.Result = await _repository.UpdateDoctor(doctorDto);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = e.Message;
            }
            return _response;
        }

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(int id)
        {
            try
            {
                _response.Result = await _repository.DeleteDoctor(id);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = e.Message;
            }
            return _response;
        }
    }
}
