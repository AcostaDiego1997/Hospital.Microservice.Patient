using AutoMapper;
using Microservice.Patients.Application.Commands.Request;
using Microservice.Patients.Application.DTO;
using Microservice.Patients.Domain.Patient;

namespace Microservice.Patients.Application.Automapper
{
    public class PatientSummary_Mapper : Profile
    {
        public PatientSummary_Mapper() {
            CreateMap<Patient, PatientSummary_DTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Dni, opt => opt.MapFrom(src => src.Dni))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));

            CreateMap<List<Patient>, List<PatientSummary_DTO>>()
                    .ConvertUsing((src, dest, context) =>
                    {
                        dest = src.Select(dto => context.Mapper.Map<PatientSummary_DTO>(dto)).ToList();

                        return dest;
                    });
        }

        
    }
}
