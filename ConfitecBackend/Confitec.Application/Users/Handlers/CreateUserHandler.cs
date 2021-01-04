using Confitec.Application.Users.Commands;
using Confitec.Application.Users.Repositories;
using Confitec.Domain.Users;
using Confitec.Domain.Users.Enums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Application.Users.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserRepository _repository;

        public CreateUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new   User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailAddress = request.EmailAddress,
                BirthDate = request.BirthDate,
                EducationLevel = request.EducationLevel
            };

            await _repository.AddAsync(user, cancellationToken);

            return user;
        }
    }
}
