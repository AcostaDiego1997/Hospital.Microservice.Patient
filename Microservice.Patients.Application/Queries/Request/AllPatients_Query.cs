using MediatR;
using Microservice.Patients.Application.DTO;

namespace Microservice.Patients.Application.Queries.Request
{
    public class AllPatients_Query : IRequest<List<Patient_DTO>>
    {
        public AllPatients_Query() { }
    }
}
