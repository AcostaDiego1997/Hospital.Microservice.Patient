using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Patients.Application.Interfaces.Service
{
    public interface IAuth_Service
    {
        string CreateToken(string email, string pass);
        bool? ValidateToken(string token);
    }
}
