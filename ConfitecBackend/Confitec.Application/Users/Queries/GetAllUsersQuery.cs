using Confitec.Domain.Users;
using MediatR;
using System.Collections.Generic;

namespace Confitec.Application.Users.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<User>>
    { }
}
