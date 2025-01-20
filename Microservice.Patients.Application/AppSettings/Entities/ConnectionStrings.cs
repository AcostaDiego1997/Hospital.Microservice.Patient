using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Patients.Application.AppSettings.Entities
{
    public class ConnectionStrings
    {
        public string Db_Dev { get; set; } = null!;
        public string Db_Test { get; set; } = null!;
        public string Db_Prod { get; set; } = null!;
    }
}
