using Microservice.Patients.Application.AppSettings;
using Microservice.Patients.Application.AppSettings.Entities;
using Microservice.Patients.Application.Interfaces.DataContext;
using Microservice.Patients.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Microservice.Patients.Api.Configuration
{
    public class DataContext_Dependency
    {
        public DataContext_Dependency(IServiceCollection services, AppSettings settings)
        {
            string conn = AppSettings_Helper.GetConnectionString(settings.Environment);


            services.AddDbContext<DataContext>(options => options.UseSqlServer(conn)
             .EnableSensitiveDataLogging()
           .LogTo(Console.WriteLine));

            services.AddScoped<IDbContextTransaction>(sp =>
            {
                var dataContext = sp.GetRequiredService<DataContext>();
                return dataContext.Database.BeginTransaction();
            });

            services.AddScoped<IDataContext, DataContext>();
        }
    }
}
