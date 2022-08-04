using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using People.Management.Domain.Core.Models;

namespace People.Management.Domain.Entites
{
    public class Schooling: Entity
    {
        public int ReferenceId { get; private set; }
        public string Description { get; private set; }
    }
}
