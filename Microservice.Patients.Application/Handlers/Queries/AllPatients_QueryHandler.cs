﻿using AutoMapper;
using MediatR;
using Microservice.Patients.Application.CQRS.Queries;
using Microservice.Patients.Application.DTO;
using Microservice.Patients.Application.Interfaces.UnitOfWork;
using Microservice.Patients.Domain.Patient;

namespace Microservice.Patients.Application.Handlers.Queries
{
    public class AllPatients_QueryHandler : IRequestHandler<AllPatients_Query, List<Patient_DTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AllPatients_QueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<Patient_DTO>> Handle(AllPatients_Query request, CancellationToken cancellationToken)
        {
            try
            {
                List<Patient> patients = _unitOfWork.Patient_Repository.GetAll();
                List<Patient_DTO> output = _mapper.Map<List<Patient_DTO>>(patients);

                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
