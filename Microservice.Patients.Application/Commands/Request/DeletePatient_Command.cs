using MediatR;

namespace Microservice.Patients.Application.Commands.Request
{
    public class DeletePatient_Command : IRequest<int?>
    {
        public int Dni { get; set; }

        public DeletePatient_Command(int dni)
        {
            Dni = dni;
        }
    }
}
