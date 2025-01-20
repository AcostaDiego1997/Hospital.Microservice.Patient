using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Patients.Application.AppSettings.Entities
{
    public class Auth
    {
        public string SecretKey { get; set; } = null!;
        public int Expire { get; set; }
        public string Issuer { get; set; } = null!;
        public string Audience { get; set; } = null!;
    }
}
