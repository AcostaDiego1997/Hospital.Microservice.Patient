using MediatR;
using Microservice.Patients.Application.DTO;

namespace Microservice.Patients.Application.Queries.Request
{
    public class PatientsById_Query : IRequest<List<Patient_DTO>>
    {
        public List<int> Ids { get; set; }

        public PatientsById_Query(){ }
        public PatientsById_Query(List<int> ids) { 
            Ids = ids;  
        }
    }
}
