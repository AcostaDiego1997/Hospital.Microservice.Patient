using Microservice.Patients.Application.Interfaces.Repository;
using Microservice.Patients.Application.Interfaces.UnitOfWork;
using Microservice.Patients.Infrastructure.Context;
using Microservice.Patients.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Microservice.Patients.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        private readonly IPatient_Repository _patientRepository;
        private IDbContextTransaction _transaction;

        public UnitOfWork(DataContext dataContext, IPatient_Repository patientRepository, IDbContextTransaction transaction)
        {
            _dataContext = dataContext;
            _patientRepository = patientRepository;
            _transaction = transaction;
        }   

        public IPatient_Repository Patient_Repository => _patientRepository ?? new Patient_Repository(_dataContext);

        public void BeginTransaction()
        {
            if (_transaction != null)
                return;

            _transaction = _dataContext.Database.BeginTransaction();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await _dataContext.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            catch (Exception ex) 
            {
                await RollBackTransactionAsync();
                throw new Exception(ex.Message);
            }
            finally
            {
                if(_transaction != null)
                {
                    _transaction.Dispose();
                    _transaction = null;
                }
            }
        }

        public void Dispose()
        {
            _dataContext.Dispose();
            if(_transaction != null)
                _transaction.Dispose();
        }

        public async Task RollBackTransactionAsync()
        {
            try
            {
                await _transaction.RollbackAsync();
            }
            catch (Exception ex)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public int SaveChanges()
        {
            int output = _dataContext.SaveChanges();
            return output;
        }
    }
}
