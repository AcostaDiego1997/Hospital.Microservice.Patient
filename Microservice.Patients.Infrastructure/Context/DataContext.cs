using Microservice.Patients.Application.Interfaces.DataContext;
using Microservice.Patients.Domain.Patient;
using Microservice.Patients.Infrastructure.TableConfig;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Patients.Infrastructure.Context
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<Patient> Patients { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Patient_TableConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
