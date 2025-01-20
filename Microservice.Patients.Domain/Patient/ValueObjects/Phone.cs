using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Patients.Domain.Patient.ValueObjects
{
    public class Phone
    {
        private readonly string _prefix = "+54 11";

        public string Value { get; init; }

        private Phone() { }
        private Phone(string number)
        {
            Value = _prefix + number;
        }

        public static Phone Create(string number)
        {
            if (!Int32.TryParse(number, out int num))
                throw new ArgumentException($"El telefono '{number}' no tiene un formato valido.");

            Validate(num);
            return new Phone(number);
        }

        private static void Validate(int number)
        {
            if (number < 0)
                throw new ArgumentException("El numero de telefono no puede ser negativo.");

            if (number.ToString().Length < 8)
                throw new ArgumentException($"El numero de telefono '{number}' es invalido. Los numeros de telefono deben tener ocho digitos.");
        }
    }
}
