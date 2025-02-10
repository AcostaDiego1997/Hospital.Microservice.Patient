using MediatR;
using Microservice.Patients.Application.DTO;

namespace Microservice.Patients.Application.Queries.Request
{
    public class PatientSummaries_Query : IRequest<List<PatientSummary_DTO>>
    {
        private readonly List<int> _dnis;

        public List<int> Dnis { get => _dnis; }

        public PatientSummaries_Query(){}
        public PatientSummaries_Query(List<int> dnis)
        {
            _dnis = dnis;
        }
    }
}
