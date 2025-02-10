using AutoMapper;
using MediatR;
using Microservice.Patients.Application.DTO;
using Microservice.Patients.Application.Interfaces.UnitOfWork;
using Microservice.Patients.Application.Queries.Request;
using Microservice.Patients.Domain.Patient;

namespace Microservice.Patients.Application.Queries.Handlers
{
    public class PatientsById_QueryHandler : IRequestHandler<PatientsById_Query, List<Patient_DTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PatientsById_QueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<Patient_DTO>> Handle(PatientsById_Query request, CancellationToken cancellationToken)
        {
            try
            {
                List<Patient_DTO> output = [];

                List<Patient> result = _unitOfWork.Patient_Repository.GetById(request.Ids);

                output = _mapper.Map<List<Patient_DTO>>(result);

                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
