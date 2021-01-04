using Confitec.Domain.Users;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Application.Users.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);

        Task<IEnumerable<User>> GetAllAsync();

        Task<User> AddAsync(User user, CancellationToken cancellationToken);

        Task<User> UpdateAsync(User user, CancellationToken cancellationToken);
        
        Task DeleteAsync(User user, CancellationToken cancellationToken);
    }
}
