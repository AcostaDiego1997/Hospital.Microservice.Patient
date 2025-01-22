using AutoMapper;
using MediatR;
using Microservice.Patients.Application.DTO;
using Microservice.Patients.Application.Interfaces.UnitOfWork;
using Microservice.Patients.Application.Queries.Request;
using Microservice.Patients.Domain.Patient;

namespace Microservice.Patients.Application.Queries.Handlers
{
    public class PatientByDni_QueryHandler : IRequestHandler<PatientByDni_Query, Patient_DTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PatientByDni_QueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Patient_DTO> Handle(PatientByDni_Query request, CancellationToken cancellationToken)
        {
            try
            {
                Patient patient = _unitOfWork.Patient_Repository.GetByDni(request.Dni) ?? throw new ArgumentException($"No existe un paciente con dni '{request.Dni}'");

                Patient_DTO output = _mapper.Map<Patient_DTO>(patient);

                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
