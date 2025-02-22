using MediatR;
using Microservice.Patients.Application.DTO;

namespace Microservice.Patients.Application.Queries.Request
{
    public class PatientByDni_Query : IRequest<GetPatient_DTO>
    {
        public int Id { get; set; }

        public PatientByDni_Query(int id)
        {
            Id = id;
        }
    }
}
