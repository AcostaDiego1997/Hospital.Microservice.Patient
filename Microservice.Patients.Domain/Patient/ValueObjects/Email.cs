using System.Text.RegularExpressions;

namespace Microservice.Patients.Domain.Patient.ValueObjects
{
    public partial class Email
    {
        private const string _pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        public string Value { get; init; }

        private Email() { }
        private Email(string value) => Value = value;

        public static Email Create(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("El usuario debe un email.");
            if (!EmailRegex().IsMatch(value)) throw new ArgumentException("El Email no tiene un formato válido.");

            return new Email(value);
        }

        [GeneratedRegex(_pattern)]
        private static partial Regex EmailRegex();
    }
}
