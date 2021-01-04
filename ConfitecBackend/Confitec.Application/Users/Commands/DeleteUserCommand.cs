using MediatR;

namespace Confitec.Application.Users.Commands
{
    public class DeleteUserCommand : IRequest
    {
        public DeleteUserCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
