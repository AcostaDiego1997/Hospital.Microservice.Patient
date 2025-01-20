
using Microservice.Patients.Application.Interfaces.JWT;
using Microservice.Patients.Application.Interfaces.Service;
using Microservice.Patients.Application.Interfaces.UnitOfWork;
using Microservice.Patients.Application.Service;
using Microservice.Patients.Infrastructure.JWT;
using Microservice.Patients.Infrastructure.UnitOfWork;

namespace Microservice.Patients.Api.Configuration
{
    public class Services_Dependencies
    {
        public Services_Dependencies(IServiceCollection services){
            services.AddScoped<IPatient_Service, Patient_Service>();
            services.AddScoped<IAuth_Service, Auth_Service>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IToken, TokenManager>();
        }
    }
}
