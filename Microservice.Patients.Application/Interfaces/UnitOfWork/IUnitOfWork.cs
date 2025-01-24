using Microservice.Patients.Application.Interfaces.Repository;

namespace Microservice.Patients.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        void BeginTransaction();
        Task CommitTransactionAsync();
        Task RollBackTransactionAsync();

        IPatient_Repository Patient_Repository { get; }
    }
}
