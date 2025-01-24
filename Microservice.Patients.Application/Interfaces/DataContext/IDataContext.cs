using Microservice.Patients.Domain.Patient;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Patients.Application.Interfaces.DataContext
{
    public interface IDataContext
    {
        DbSet<Patient> Patients { get; set; }
    }
}