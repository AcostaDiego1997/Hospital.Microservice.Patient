using MediatR;
using Microservice.Patients.Application.DTO;

namespace Microservice.Patients.Application.Queries.Request
{
    public class PatientsSummaries_Query : IRequest<List<PatientsSummaries_DTO>>
    {
        private readonly List<int> _ids;

        public List<int> Ids{ get => _ids; }

        public PatientsSummaries_Query(List<int> ids)
        {
            _ids = ids;
        }
    }
}
