using People.Management.Domain.Core.Models;
using People.Management.Domain.Entites.Validations;
using People.Management.Domain.ValueObjects;

namespace People.Management.Domain.Entites
{
    public class User : Entity
    {
        public int ReferenceId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Guid? SchoolingId { get; private set; }
        public Guid? SchoolRecordId { get; private set; }
        public virtual Schooling Schooling { get; private set; }
        public virtual SchoolRecord SchoolRecord { get; private set; }
        public virtual AdressInformation AdressInformation { get; private set; }


        public override bool IsValid()
        {
            ValidationResult = new UserValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        protected User() { }

        public User(string firstName, string lastName, string email, DateTime birthDate,
            string adress, string city, string country, int? number, string uf, string zipCode)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            AdressInformation = new AdressInformation(
                adress,
                city,
                country,
                number,
                uf,
                zipCode);
        }

        public void Update(string firstName, string lastName, string email, DateTime birthDate,
            string adress, string city, string country, int? number, string uf, string zipCode)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            AdressInformation = new AdressInformation(
                adress,
                city,
                country,
                number,
                uf,
                zipCode);
        }

        public void AddSchooling(Guid schoolingId)
        {
            Schooling = new Schooling(this, schoolingId);
        }

        public void AddSchoolRecord(string format, string name)
        {
            SchoolRecord = new SchoolRecord(this, format, name);
        }
    }
}
