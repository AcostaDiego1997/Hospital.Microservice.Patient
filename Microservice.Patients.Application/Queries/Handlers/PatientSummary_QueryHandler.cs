using AutoMapper;
using MediatR;
using Microservice.Patients.Application.DTO;
using Microservice.Patients.Application.Interfaces.UnitOfWork;
using Microservice.Patients.Application.Queries.Request;
using Microservice.Patients.Domain.Patient;

namespace Microservice.Patients.Application.Queries.Handlers
{
    public class PatientSummary_QueryHandler : IRequestHandler<PatientSummary_Query, PatientSummary_DTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PatientSummary_QueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PatientSummary_DTO> Handle(PatientSummary_Query request, CancellationToken cancellationToken)
        {
            try
            {
                Patient patient = _unitOfWork.Patient_Repository.GetByDni(request.Dni) ?? throw new Exception($"No existe un paciente con dni {request.Dni}");

                PatientSummary_DTO output = _mapper.Map<PatientSummary_DTO>(patient);

                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
