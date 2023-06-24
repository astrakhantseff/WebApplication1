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
        public async Task<IEnumerable<GetDoctorsDto>> Get([FromQuery] int page, [FromQuery] string sort)
        {
            try
            {
                return await _repository.GetDoctors(page, sort);
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
