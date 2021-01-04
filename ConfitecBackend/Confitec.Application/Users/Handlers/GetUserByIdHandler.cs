using Confitec.Application.Users.Queries;
using Confitec.Application.Users.Repositories;
using Confitec.Domain.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Application.Users.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserRepository _repository;

        public GetUserByIdHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
