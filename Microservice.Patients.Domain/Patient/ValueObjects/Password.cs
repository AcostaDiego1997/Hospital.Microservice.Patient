using System.Text.RegularExpressions;

namespace Microservice.Patients.Domain.Patient.ValueObjects
{
    public partial class Password
    {
        private const string _pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{10,}$";
        public string Value { get; init; }

        private Password() { }
        private Password(string value) => Value = value;

        public static Password Create(string value)
        {
            if (string.IsNullOrEmpty(value) || !PasswordRegex().IsMatch(value))
                throw new ArgumentException("La contraseña no es segura.");

            return new Password(value);
        }

        [GeneratedRegex(_pattern)]
        private static partial Regex PasswordRegex();
    }
}
