using Microservice.Patients.Application.DTO;
using Microservice.Patients.Application.Interfaces.Repository;
using Microservice.Patients.Domain.Patient;
using Microservice.Patients.Infrastructure.Context;
using System.Data.Entity;
using System.Net;

namespace Microservice.Patients.Infrastructure.Repositories
{
    public class Patient_Repository : IPatient_Repository
    {
        private DataContext _dataContext;

        public Patient_Repository(DataContext dataContext) { 
            _dataContext = dataContext;
        }

        public void Add(Patient patient)
        {
            try
            {
                _dataContext.Patients.Add(patient);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int? Delete(int dni)
        {
            try
            {
                Patient? patient = GetByDni(dni);
                if (patient == null) return null;

                patient.SetStatus(false);
                _dataContext.Patients.Update(patient);
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Patient> GetAll()
        {
            try
            {
                return _dataContext.Patients.ToList();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }   
        }

        public Patient? GetByDni(int dni)
        {
            try
            {
                return _dataContext.Patients.Where(p => p.Dni == dni).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Patient>? GetByDni(List<int> dnis)
        {
            return _dataContext.Patients.Where(p => dnis.Contains(p.Dni)).ToList();
        }

        public Patient? GetByEmail(string email)
        {
            try
            {
                return _dataContext.Patients.Where(p => p.Email.Value == email).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Patient> GetById(List<int> ids)
        {
            return [.. _dataContext.Patients.Where(p => ids.Contains(p.Id))];
        }

        public int UniquePatientValidation(GetPatient_DTO dto)
        {
            try
            {
                int output = _dataContext.Patients.Where(p => p.Dni == dto.Dni || p.Email.Value == dto.Email).Count();

                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
