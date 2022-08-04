using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using People.Management.Domain.Core.Models;

namespace People.Management.Domain.Entites
{
    public class SchoolRecord: Entity
    {
        public string Format { get; private set; }
        public string Name { get; private set; }
        public virtual User User { get; private set; }

        protected SchoolRecord() { }

        public SchoolRecord(User user, string format, string name)
        {
            User = user;
            Format = format;
            Name = name;
        }
    }
}
