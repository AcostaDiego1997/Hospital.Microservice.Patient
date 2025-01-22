﻿using AutoMapper;
using MediatR;
using Microservice.Patients.Application.CQRS.Commands;
using Microservice.Patients.Application.Interfaces.UnitOfWork;
using Microservice.Patients.Domain.Patient;

namespace Microservice.Patients.Application.Handlers.Commands
{
    public class CreatePatient_CommandHandler : IRequestHandler<CreatePatient_Command, int>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CreatePatient_CommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePatient_Command request, CancellationToken cancellationToken)
        {
            try
            {
                Patient patient = _mapper.Map<Patient>(request);
                await _unitOfWork.BeginTransactionAsync();
                _unitOfWork.Patient_Repository.Add(patient);
                int output = await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                if (output == 0)
                    throw new ArgumentException("No se pudo insertar al Paciente.");

                return output;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollBackTransactionAsync();
                throw new Exception(ex.Message);
            }
        }
    }
}
