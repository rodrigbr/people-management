using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public Guid SchoolingId { get; private set; }
        public Guid SchoolRecordId { get; private set; }
        public virtual Schooling Schooling { get; private set; }
        public virtual SchoolRecord SchoolRecord { get; private set; }
        public virtual AdressInformation AdressInformation { get; private set; }


        public override bool IsValid()
        {
            ValidationResult = new UserValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
