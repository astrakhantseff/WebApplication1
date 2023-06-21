using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Migrations;
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

        [HttpGet("{sort}/{page}")]
        public async Task<IEnumerable<GetPatientsDto>> Get(string sort, int page)
        {
            try
            {
                IEnumerable<PatientsDto> patients = await _repository.GetPatients();
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

                result = sort.ToLower() switch
                {
                    "family" => result.OrderBy(column => column.Family),
                    "firstname" => result.OrderBy(column => column.FirstName),
                    "secondname" => result.OrderBy(column => column.SecondName),
                    "address" => result.OrderBy(column => column.Address),
                    "dateofbirth" => result.OrderBy(column => column.DateOfBirth),
                    "sex" => result.OrderBy(column => column.Sex),
                    "numberofregion" => result.OrderBy(column => column.NumberOfRegion),
                    _ => result
                };

                return page > 0
                    ? result.Skip((page - 1) * _pageSize).Take(_pageSize).ToList()
                    : result;
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
