using System.Security.AccessControl;

namespace People.Management.Framework.DTOs.Schooling
{
    public class SchoolingWriteDTO
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Guid SchoolingTypeId { get; set; }
    }
}
