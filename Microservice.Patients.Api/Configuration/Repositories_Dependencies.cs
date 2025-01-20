using Microservice.Patients.Application.Interfaces.Repository;
using Microservice.Patients.Infrastructure.Repositories;

namespace Microservice.Patients.Api.Configuration
{
    public class Repositories_Dependencies
    {
        public Repositories_Dependencies(IServiceCollection services) {
            services.AddScoped<IPatient_Repository, Patient_Repository>();            
        }
    }
}
