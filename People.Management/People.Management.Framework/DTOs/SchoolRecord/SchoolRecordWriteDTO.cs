namespace People.Management.Framework.DTOs.SchoolRecord
{
    public class SchoolRecordWriteDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Format { get; set; }
        public string Name { get; set; }
    }
}
