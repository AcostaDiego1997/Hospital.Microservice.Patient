﻿using AutoMapper;
using MediatR;
using Microservice.Patients.Application.DTO;
using Microservice.Patients.Application.Interfaces.UnitOfWork;
using Microservice.Patients.Application.Queries.Request;
using Microservice.Patients.Domain.Patient;

namespace Microservice.Patients.Application.Queries.Handlers
{
    public class PatientSummaries_QueryHandler : IRequestHandler<PatientSummaries_Query, List<PatientSummary_DTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PatientSummaries_QueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<PatientSummary_DTO>> Handle(PatientSummaries_Query request, CancellationToken cancellationToken)
        {
            try
            {
                List<Patient> patients = _unitOfWork.Patient_Repository.GetAll() ?? throw new Exception($"No se obtuvieron pacientes.");

                List<PatientSummary_DTO> output = _mapper.Map<List<PatientSummary_DTO>>(patients);

                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
