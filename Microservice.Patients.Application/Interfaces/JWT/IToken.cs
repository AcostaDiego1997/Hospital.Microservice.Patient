using Microservice.Patients.Domain.Patient;

namespace Microservice.Patients.Application.Interfaces.JWT
{
    public interface IToken
    {
        string CreateToken(Patient patient);
        bool? ValidateToken(string token);
    }
}
