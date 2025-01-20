using Microservice.Patients.Application.Interfaces.Repository;

namespace Microservice.Patients.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
        void BeginTransaction();
        void CommitTransaction();
        void RollBackTransaction();

        IPatient_Repository Patient_Repository { get; }
    }
}
