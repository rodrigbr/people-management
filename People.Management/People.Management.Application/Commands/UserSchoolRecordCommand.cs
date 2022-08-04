using Microsoft.AspNetCore.Http;
using People.Management.Domain.Core.Models;
using People.Management.Domain.Entites;

namespace People.Management.Application.Commands
{
    public abstract class UserSchoolRecordCommand : Command
    {
        public Guid UserId { get; protected set; }
        public string Format { get; protected set; }
        public string Name { get; protected set; }
    }
}
