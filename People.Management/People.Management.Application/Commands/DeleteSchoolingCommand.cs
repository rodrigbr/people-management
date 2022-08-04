namespace People.Management.Application.Commands
{
    public class DeleteSchoolingCommand : DeleteCommand
    {
        public DeleteSchoolingCommand(Guid id)
        {
            Id = id;
        }
    }
}
