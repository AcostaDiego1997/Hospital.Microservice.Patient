using Microservice.Patients.Application.Automapper;

namespace Microservice.Patients.Api.Configuration
{
    public class AutoMapper_Config
    {
        public AutoMapper_Config(IServiceCollection services) 
        {
            services.AddAutoMapper(prf =>
            {
                prf.AddProfile<Patient_Mapper>();
            });
        }
    }
}
