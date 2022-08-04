using Microsoft.AspNetCore.Http;
using People.Management.Domain.Core.Models;
using People.Management.Domain.Entites;

namespace People.Management.Application.Commands
{
    public abstract class UserSchoolingCommand : Command
    {
        public Guid UserId { get; protected set; }
        public Guid SchoolingId { get; protected set; }
    }
}
