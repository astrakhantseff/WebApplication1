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
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsRepository _repository;

        private readonly ResponseDto _response;

        private const int _pageSize = 10;

        public DoctorsController(IDoctorsRepository repository, ResponseDto response)
        {
            _repository = repository;
            _response = response;
        }

        [HttpGet("{sort}/{page}")]
        public async Task<IEnumerable<GetDoctorsDto>> Get(string sort, int page)
        {
            try
            {
                IEnumerable<DoctorsDto> doctors = await _repository.GetDoctors();
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

                result = sort.ToLower() switch
                {
                    "fullname" => result.OrderBy(column => column.FullName),
                    "cabinet" => result.OrderBy(column => column.NumberOfCab),
                    "region" => result.OrderBy(column => column.NumberOfRegion),
                    "specialty" => result.OrderBy(column => column.NameOfSpecialty),
                    _ => result
                };

                if (page != 0)
                {
                    result = result.Skip((page - 1) * _pageSize).Take(_pageSize).ToList();
                }

                return result;
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
