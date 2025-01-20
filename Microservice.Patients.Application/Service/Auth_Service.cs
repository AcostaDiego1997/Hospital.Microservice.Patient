using Microservice.Patients.Application.Interfaces.JWT;
using Microservice.Patients.Application.Interfaces.Service;
using Microservice.Patients.Application.Interfaces.UnitOfWork;
using Microservice.Patients.Domain.Patient;

namespace Microservice.Patients.Application.Service
{
    public class Auth_Service : IAuth_Service
    {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IToken _tokenService;

        public Auth_Service(IUnitOfWork unitOfWork, IToken tokenService)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }

        public string CreateToken(string email, string pass)
        {
            try
            {
                Patient? patient = _unitOfWork.Patient_Repository.GetByEmail(email) ?? throw new ArgumentException($"No se encuentra un paciente con el email '{email}'");

                ValidatePassword(patient.Password.Value, pass);

                string output = _tokenService.CreateToken(patient);

                return output;
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBackTransaction();
                throw new Exception(ex.Message);
            }
        }

        public bool? ValidateToken(string token)
        {
            throw new NotImplementedException();
        }

        private void ValidatePassword(string passInDb, string passDto)
        {
            if (passInDb != passDto)
                throw new ArgumentException("Los datos ingresados son incorrectos.");
        }

        
    }
}
