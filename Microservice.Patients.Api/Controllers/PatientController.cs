using MediatR;
using Microservice.Patients.Application.Commands.Request;
using Microservice.Patients.Application.DTO;
using Microservice.Patients.Application.Interfaces.Service;
using Microservice.Patients.Application.Queries.Request;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Patients.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IAuth_Service _authservice;
        private readonly IMediator _mediator;

        public PatientController( IAuth_Service authservice, IMediator mediator) {
            _authservice = authservice;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int dni)
        {
            try
            {
                //Patient_DTO? output = _service.GetByDni(dni);
                Patient_DTO output = await _mediator.Send(new PatientByDni_Query(dni));

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
                List<Patient_DTO> output = await _mediator.Send(new AllPatients_Query());
                
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
        public async Task<IActionResult> PostMadiatr(Patient_DTO dto)
        {
            try
            {
                CreatePatient_Command req = new(dto);
                await _mediator.Send(req);
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
                //int? output = await _service.Delete(dni);
                int? output = await _mediator.Send(new DeletePatient_Command(dni));
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
