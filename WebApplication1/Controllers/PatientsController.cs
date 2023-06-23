using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Dto;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientsRepository _repository;

        private readonly ResponseDto _response;

        private const int _pageSize = 10;

        public PatientsController(IPatientsRepository repository)
        {
            _repository = repository;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<IEnumerable<GetPatientsDto>> Get([FromQuery] string sort, [FromQuery] int page)
        {
            try
            {
                IEnumerable<PatientsDto> patients = await _repository.GetPatients(page);

                IEnumerable<Region> regions = await _repository.GetRegions();

                IEnumerable<GetPatientsDto> result = from patient in patients
                                                     join region in regions on patient.RegionId equals region.Id
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
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = e.Message;
                return null;
            }
        }

        [HttpGet("{id}")]
        public async Task<GetPatientByIdDto> GetById(int id)
        {
            try
            {
                return await _repository.GetPatientById(id);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = e.Message;
                return null;
            }
        }

        [HttpPost]
        public async Task<ResponseDto> Post([FromBody] PatientsDto patientsDto)
        {
            try
            {
                _response.Result = await _repository.CreatePatient(patientsDto);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = e.Message;
            }
            return _response;
        }

        [HttpPut("{id}")]
        public async Task<ResponseDto> Put(int id, [FromBody] PatientsDto patientsDto)
        {
            try
            {
                _response.Result = await _repository.UpdatePatient(patientsDto);
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
                _response.Result = await _repository.DeletePatient(id);
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
