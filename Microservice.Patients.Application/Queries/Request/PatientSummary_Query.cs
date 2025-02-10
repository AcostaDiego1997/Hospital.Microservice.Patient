using MediatR;
using Microservice.Patients.Application.DTO;

namespace Microservice.Patients.Application.Queries.Request
{
    public class PatientSummary_Query : IRequest<PatientSummary_DTO>
    {
        private readonly int _dni;
        public int Dni { get => _dni; }

        public PatientSummary_Query() { }
        public PatientSummary_Query(int dni)
        {
            _dni = dni;
        }
    }
}
