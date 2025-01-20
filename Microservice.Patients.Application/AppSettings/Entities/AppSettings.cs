using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Patients.Application.AppSettings.Entities
{
    public class AppSettings
    {
        public string Environment { get; set; } = null!;
        public ConnectionStrings ConnectionStrings { get; set; } = null!;
        public Auth Auth { get; set; } = null!;
    }
}
