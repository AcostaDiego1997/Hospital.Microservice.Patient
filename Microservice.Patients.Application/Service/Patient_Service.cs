using AutoMapper;
using Microservice.Patients.Application.DTO;
using Microservice.Patients.Application.Interfaces.Service;
using Microservice.Patients.Application.Interfaces.UnitOfWork;
using Microservice.Patients.Domain.Patient;

namespace Microservice.Patients.Application.Service
{
    public class Patient_Service : IPatient_Service
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Patient_Service(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<Patient_DTO> GetAll()
        {
            try
            {
                List<Patient> patients = _unitOfWork.Patient_Repository.GetAll();
                List<Patient_DTO> output = _mapper.Map<List<Patient_DTO>>(patients);

                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Patient_DTO? GetByDni(int dni)
        {
            try
            {
                Patient? patient = _unitOfWork.Patient_Repository.GetByDni(dni);
                if (patient == null)
                    return null;

                Patient_DTO output = _mapper.Map<Patient_DTO>(patient);
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Patient_DTO? Post(Patient_DTO dto)
        {
            try
            {
                ValidateUniquePatient(dto);

                Patient output = _mapper.Map<Patient>(dto);
                _unitOfWork.BeginTransaction();
                _unitOfWork.Patient_Repository.Add(output); 
                _unitOfWork.SaveChanges();
                _unitOfWork.CommitTransaction();
                return dto;
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBackTransaction();
                throw new Exception(ex.Message);
            }
        }


        public int? Delete(int dni)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                int? patient = _unitOfWork.Patient_Repository.Delete(dni);

                _unitOfWork.SaveChanges();
                _unitOfWork.CommitTransaction();

                return patient;
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBackTransaction();
                throw new Exception(ex.Message);
            }
        }

        private void ValidateUniquePatient(Patient_DTO dto)
        {
            int result = _unitOfWork.Patient_Repository.UniquePatientValidation(dto);
            if (result > 0)
                throw new Exception($"Ya se encuentra dado de alta un paciente los datos solicitados.");
        }
    }
}
