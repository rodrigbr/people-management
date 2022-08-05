using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using People.Management.Framework.DTOs.Schooling;
using People.Management.Framework.DTOs.SchoolRecord;

namespace People.Management.Framework.DTOs.User
{
    public class UserReadDTO
    {
        public Guid Id { get; set; }
        public int ReferenceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int? Number { get; set; }
        public string Uf { get; set; }
        public string ZipCode { get; set; }
        public Guid? SchoolingId { get; set; }
        public Guid? SchoolRecordId { get; set; }
        public Guid? SchoolingTypeId { get; set; }
        public string SchoolingTypeName { get; set; }
        public string SchoolRecordFormat { get; set; }
        public string SchoolRecordName { get; set; }
    }
}
