namespace People.Management.Application.Commands
{
    public class DeleteSchoolRecordCommand : DeleteCommand
    {
        public DeleteSchoolRecordCommand(Guid id)
        {
            Id = id;
        }
    }
}
