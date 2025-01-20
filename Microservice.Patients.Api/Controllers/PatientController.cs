using Microservice.Patients.Application.DTO;
using Microservice.Patients.Application.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Patients.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatient_Service _service;
        private readonly IAuth_Service _authservice;

        public PatientController(IPatient_Service patientService, IAuth_Service authservice) {
            _service = patientService;
            _authservice = authservice;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int dni)
        {
            try
            {
                Patient_DTO? output = _service.GetByDni(dni);
                return Ok(new {
                    IsSuccess = true,
                    Message = (output != null) ? "Paciente obtenido con exito" : "El dni ingresado no corresponde a ningun paciente",
                    Entity = output
                });
            }
            catch (Exception ex) {
                return BadRequest(new
                {
                    IsSuccess = false,
                    Message = ex.Message
                });
            }
        }

        [HttpGet("/all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Patient_DTO> output = _service.GetAll();
                return Ok(new
                {
                    IsSuccess = true,
                    Message = "Pacientes obtenidos con exito",
                    Entity = output
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    IsSuccess = false,
                    Message = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Patient_DTO dto)
        {
            try
            {
                _service.Post(dto);
                return Ok(new
                {
                    IsSuccess = true,
                    Message = "Paciente insertado con exito",
                    Entity = dto
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    IsSuccess = false,
                    Message = ex.Message
                });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int dni)
        {
            try
            {
                int? output = _service.Delete(dni);
                return Ok(new
                {
                    IsSuccess = true,
                    Message = (output != null) ? "Paciente eliminado exitosamente" : "El dni ingresado no corresponde a ningun paciente",
                    Entity = output
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    IsSuccess = false,
                    Message = ex.Message
                });
            }
        }

    }
}
