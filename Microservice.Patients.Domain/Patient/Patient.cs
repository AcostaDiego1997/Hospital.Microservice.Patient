
using Microservice.Patients.Domain.Patient.ValueObjects;

namespace Microservice.Patients.Domain.Patient
{
    public class Patient
    {
        private int _id;
        private readonly int _dni;
        private string _name;
        private string _lastname;
        private Email _email;
        private Password _password;
        private Phone _phone;
        private DateTime _birthday;
        private bool _status;

        public Patient() {
            _status = true;
        }

        public Patient(int dni, string name, string lastname, string email, string password, string phone)
        {
            _dni = dni;
            _name = name;
            _lastname = lastname;
            _email = Email.Create(email);
            _password = Password.Create(password);
            _phone = Phone.Create(phone);
            _status = true;
        }

        public int Id { get => _id; }
        public int Dni { get => _dni; }
        public string Name { get => _name; }
        public string LastName { get => _lastname; }
        public bool Status { get => _status; }
        public Email Email { get => _email; }
        public Password Password { get => _password; }
        public Phone Phone { get => _phone; }
        public void SetName(string newName) => _name = newName;
        public void SetLastName(string newLastName) => _lastname = newLastName;
        public void SetStatus(bool newStatus) => _status = newStatus;
        public void SetEmail(string newEmail) => _email = Email.Create(newEmail);
        public void SetPassword(string newPassword) => _password = Password.Create(newPassword);
        public void SetPhone(string newPhone) => _phone = Phone.Create(newPhone);
    }
}
