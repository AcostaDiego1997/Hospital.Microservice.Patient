using Microservice.Patients.Application.DTO;
using Microservice.Patients.Domain.Patient;

namespace Microservice.Patients.Application.Interfaces.Repository
{
    public interface IPatient_Repository
    {
        void Add(Patient patient);
        Patient? GetByDni(int dni);
        Patient? GetByEmail(string email);
        List<Patient> GetAll();
        int? Delete(int dni);
        int UniquePatientValidation(Patient_DTO dto);
    }
}
