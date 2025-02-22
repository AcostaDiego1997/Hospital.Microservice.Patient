using AutoMapper;
using MediatR;
using Microservice.Patients.Application.DTO;
using Microservice.Patients.Application.Interfaces.UnitOfWork;
using Microservice.Patients.Application.Queries.Request;
using Microservice.Patients.Domain.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Patients.Application.Queries.Handlers
{
    public class PatientsSummaries_QueryHandler : IRequestHandler<PatientsSummaries_Query, List<PatientsSummaries_DTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PatientsSummaries_QueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<List<PatientsSummaries_DTO>> Handle(PatientsSummaries_Query request, CancellationToken cancellationToken)
        {
            try
            {
                List<Patient> patients = _unitOfWork.Patient_Repository.GetById(request.Ids);

                List<PatientsSummaries_DTO> output = _mapper.Map<List<PatientsSummaries_DTO>>(patients);

                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
