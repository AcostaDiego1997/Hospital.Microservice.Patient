using Microservice.Patients.Application.DTO;

namespace Microservice.Patients.Application.Interfaces.Service
{
    public interface IPatient_Service
    {
        Patient_DTO? GetByDni(int dni);
        List<Patient_DTO> GetAll();
        Patient_DTO? Post(Patient_DTO dto);
        int? Delete(int dni);
    }
}
