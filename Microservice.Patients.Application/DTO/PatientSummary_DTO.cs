using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Patients.Application.DTO
{
    public class PatientSummary_DTO
    {
        public int Id { get; set; }
        public int Dni { get; set; }
        public string FullName { get; set; } = null!;
    }
}
