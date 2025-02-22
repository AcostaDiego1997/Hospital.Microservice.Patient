using AutoMapper;
using Microservice.Patients.Application.DTO;
using Microservice.Patients.Domain.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Patients.Application.Automapper
{
    public class PatientsSummaries_Mapper : Profile
    {
        public PatientsSummaries_Mapper() {
            CreateMap<Patient, PatientsSummaries_DTO>()
                .ForMember(dest => dest.Dni, opt => opt.MapFrom(src => src.Dni))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone.Value));

            CreateMap<List<Patient>, List<PatientsSummaries_DTO>>()
                    .ConvertUsing((src, dest, context) =>
                    {
                        dest = src.Select(dto => context.Mapper.Map<PatientsSummaries_DTO>(dto)).ToList();

                        return dest;
                    });
        }
    }
}
