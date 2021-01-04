using Confitec.Application.Users.Commands;
using Confitec.Application.Users.Repositories;
using Confitec.Domain.Users.Enums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Application.Users.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IUserRepository _repository;

        public UpdateUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);

            if (user == null)
            {
                return 0;
            }

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.EmailAddress = request.EmailAddress;
            user.BirthDate = request.BirthDate;
            user.EducationLevel = (EducationLevel)request.EducationLevel;

            await _repository.UpdateAsync(user, cancellationToken);

            return 1;
        }
    }
}
