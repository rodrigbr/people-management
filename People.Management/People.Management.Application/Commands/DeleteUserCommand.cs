
namespace People.Management.Application.Commands
{
    public class DeleteUserCommand : DeleteCommand
    {
        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }
    }
}
