using MediatR;
using Microservice.Patients.Application.DTO;

namespace Microservice.Patients.Application.CQRS.Queries
{
    public class PatientByDni_Query : IRequest<Patient_DTO>
    {
        public int Dni { get; set; }

        public PatientByDni_Query(int dni)
        {
            Dni = dni;
        }
    }
}
