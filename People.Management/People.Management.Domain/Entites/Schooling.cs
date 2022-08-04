using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using People.Management.Domain.Core.Models;
using People.Management.Domain.Statics;

namespace People.Management.Domain.Entites
{
    public class Schooling : Entity
    {
        public Guid SchoolingId { get; private set; }
        public virtual User User { get; private set; }
        public virtual SchoolingType Description { get; private set; }

        protected Schooling() { }

        public Schooling(User user, Guid schoolingId)
        {
            User = user;
            SchoolingId = schoolingId;
            Description = new SchoolingType(schoolingId, SchoolingTypeStatic.GetById(SchoolingId).Name);
        }
    }
}
