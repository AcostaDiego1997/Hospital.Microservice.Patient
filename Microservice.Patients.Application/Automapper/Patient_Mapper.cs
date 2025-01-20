using AutoMapper;
using Microservice.Patients.Application.DTO;
using Microservice.Patients.Domain.Patient;

namespace Microservice.Patients.Application.Automapper
{
    public class Patient_Mapper : Profile
    {
        public Patient_Mapper() {

            CreateMap<Patient_DTO, Patient>()
                .ForMember(dest => dest.Dni, opt => opt.MapFrom(src => src.Dni))
                .ForMember(dest => dest.Name, opt => opt.Ignore())
                .ForMember(dest => dest.LastName, opt => opt.Ignore())
                .ForMember(dest => dest.Email, opt => opt.Ignore())
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .AfterMap((src, dest) =>
                {
                    dest.SetName(src.Name);
                    dest.SetLastName(src.LastName);
                    dest.SetStatus(true);
                    dest.SetEmail(src.Email);
                    dest.SetPassword(src.Password);
                    dest.SetPhone(src.Phone);
                });

            CreateMap<Patient, Patient_DTO>()
                .ForMember(dest => dest.Dni, opt => opt.MapFrom(src => src.Dni))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone.Value));


            CreateMap<List<Patient>, List<Patient_DTO>>()
                .ConvertUsing((src, dest, context) =>
                {
                    dest = src.Select(dto => context.Mapper.Map<Patient_DTO>(dto)).ToList();

                    return dest;
                });
        }
    }
}
