using AutoMapper;
using MediatR;
using Microservice.Patients.Application.Commands.Request;
using Microservice.Patients.Application.Interfaces.UnitOfWork;
using Microservice.Patients.Domain.Patient;

namespace Microservice.Patients.Application.Commands.Handlers
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
                _unitOfWork.BeginTransaction();
                _unitOfWork.Patient_Repository.Add(patient);
                int output = _unitOfWork.SaveChanges();
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
