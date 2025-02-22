using MediatR;
using Microservice.Patients.Application.DTO;
using Microservice.Patients.Domain.Patient.ValueObjects;

namespace Microservice.Patients.Application.Commands.Request
{
    public class CreatePatient_Command : IRequest<int>
    {
        public int Dni { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Phone { get; set; } = null!;


        public CreatePatient_Command() { }
        public CreatePatient_Command(PostPatient_DTO dto)
        {
            Dni = dto.Dni;
            Name = dto.Name;
            LastName = dto.LastName;
            Email = dto.Email;
            Password = dto.Password;
            Phone = dto.Phone;
        }
    }
}
