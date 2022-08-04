using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using People.Management.Domain.Core.Models;

namespace People.Management.Domain.Entites
{
    public class SchoolingType : Entity
    {
        public SchoolingType(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Constructor without parameters to EF.
        /// </summary>
        protected SchoolingType() { }

        public string Name { get; private set; }
    }
}
