using Microservice.Patients.Application.Commands.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Patients.Api.Configuration
{
    public class Mediatr_Config
    {
        public Mediatr_Config(IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining(typeof(CreatePatient_CommandHandler));
            });
        }
    }
}
