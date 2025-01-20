using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Patients.Application.DTO
{
    public class HttpResponse_DTO
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
    }
}
