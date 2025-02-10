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

                return Ok(new HttpResponse_DTO<Patient_DTO>
                {
                    IsSuccess = true,
                    Message = (output != null) ? "Paciente obtenido con exito" : "El dni ingresado no corresponde a ningun paciente",
                    Entity = output
                });
            }
            catch (Exception ex) {
                return BadRequest(new HttpResponse_DTO<Patient_DTO>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Entity = new Patient_DTO()
                });
            }
        }

        [HttpGet("/all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Patient_DTO> output = await _mediator.Send(new AllPatients_Query());
                
                return Ok(new HttpResponse_DTO<List<Patient_DTO>>
                {
                    IsSuccess = true,
                    Message = "Pacientes obtenidos con exito",
                    Entity = output
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new HttpResponse_DTO<List<Patient_DTO>>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Entity = []
                });
            }
        }

        [HttpGet("/list")]
        public async Task<IActionResult> GetByIds([FromQuery] List<int> ids)
        {
            try
            {
                List<Patient_DTO> output = await _mediator.Send(new PatientsById_Query(ids));

                return Ok(new HttpResponse_DTO<List<Patient_DTO>>
                {
                    IsSuccess = true,
                    Message = "Pacientes obtenidos con exito",
                    Entity = output
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new HttpResponse_DTO<List<Patient_DTO>>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Entity = []
                });
            }
        }


        [HttpPost]
        public async Task<IActionResult> PostMadiatr(Patient_DTO dto)
        {
            try
            {
                await _mediator.Send(new CreatePatient_Command(dto));
                return Ok(new HttpResponse_DTO<Patient_DTO>
                {
                    IsSuccess = true,
                    Message = "Paciente insertado con exito",
                    Entity = dto
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new HttpResponse_DTO<Patient_DTO>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Entity = dto
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
                return Ok(new HttpResponse_DTO<int?>
                {
                    IsSuccess = true,
                    Message = (output != null) ? "Paciente eliminado exitosamente" : "El dni ingresado no corresponde a ningun paciente",
                    Entity = output
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new HttpResponse_DTO<int?>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Entity = -1
                });
            }
        }

        [HttpGet("/summary/{dni}")]
        public async Task<IActionResult> GetSummary(int dni)
        {
            try
            {
                PatientSummary_DTO? output = await _mediator.Send(new PatientSummary_Query(dni));

                return Ok(new HttpResponse_DTO<PatientSummary_DTO>
                {
                    IsSuccess = true,
                    Message = (output != null) ? "PAciente obtenido con exito" : "El dni ingresado no corresponde a ningun paciente",
                    Entity = output
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new HttpResponse_DTO<PatientSummary_DTO>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Entity = new PatientSummary_DTO()
                });
            }
        }
        [HttpGet("/summary")]
        public async Task<IActionResult> GetSummaries([FromQuery] List<int> dnis)
        {
            try
            {
                List<PatientSummary_DTO>? output = await _mediator.Send(new PatientSummaries_Query(dnis));

                return Ok(new HttpResponse_DTO<List<PatientSummary_DTO>>
                {
                    IsSuccess = true,
                    Message = (output != null) ? "Pacientes obtenidos con exito" : "Los Dnis ingresados no corresponden a ningun paciente",
                    Entity = output
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new HttpResponse_DTO<PatientSummary_DTO>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Entity = new PatientSummary_DTO()
                });
            }
        }
    }
}
