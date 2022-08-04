using Microsoft.AspNetCore.Http;
using People.Management.Domain.Core.Models;

namespace People.Management.Application.Commands
{
    public abstract class UserCommand : Command
    {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; protected set; }
        public DateTime BirthDate { get; protected set; }
        public string Adress { get; protected set; }
        public string City { get; protected set; }
        public string Country { get; protected set; }
        public int? Number { get; protected set; }
        public string Uf { get; protected set; }
        public string ZipCode { get; protected set; }
    }
}
