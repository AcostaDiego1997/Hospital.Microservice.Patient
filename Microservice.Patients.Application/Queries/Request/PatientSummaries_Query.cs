using MediatR;
using Microservice.Patients.Application.DTO;

namespace Microservice.Patients.Application.Queries.Request
{
    public class PatientSummaries_Query : IRequest<List<PatientSummary_DTO>>{ }
}
