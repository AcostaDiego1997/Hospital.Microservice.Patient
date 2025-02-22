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
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                GetPatient_DTO output = await _mediator.Send(new PatientByDni_Query(id));

                return Ok(new HttpResponse_DTO<GetPatient_DTO>
                {
                    IsSuccess = true,
                    Message = (output != null) ? "Paciente obtenido con exito" : "El dni ingresado no corresponde a ningun paciente",
                    Entity = output
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new HttpResponse_DTO<GetPatient_DTO>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Entity = new GetPatient_DTO()
                });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<GetPatient_DTO> output = await _mediator.Send(new AllPatients_Query());

                return Ok(new HttpResponse_DTO<List<GetPatient_DTO>>
                {
                    IsSuccess = true,
                    Message = "Pacientes obtenidos con exito",
                    Entity = output
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new HttpResponse_DTO<List<GetPatient_DTO>>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Entity = []
                });
            }
        }
        [HttpGet("summaries")]
        public async Task<IActionResult> GetSummaries([FromQuery] List<int> id)
        {
            HttpResponse_DTO<List<PatientsSummaries_DTO>>? output = new();
            try
            {
                
                output.Entity = await _mediator.Send(new PatientsSummaries_Query(id));
                output.IsSuccess = true;
                output.Message = "Resumenes obtenidos con exito.";
                return Ok(output);
            }
            catch (Exception ex)
            {
                output.IsSuccess = false;
                output.Message = ex.Message;
                output.Entity = new();
                return BadRequest(output);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(PostPatient_DTO dto)
        {
            try
            {
                await _mediator.Send(new CreatePatient_Command(dto));
                return Ok(new HttpResponse_DTO<PostPatient_DTO>
                {
                    IsSuccess = true,
                    Message = "Paciente insertado con exito",
                    Entity = dto
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new HttpResponse_DTO<PostPatient_DTO>
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
    }
}
