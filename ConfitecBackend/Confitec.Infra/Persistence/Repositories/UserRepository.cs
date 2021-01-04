using Confitec.Application.Users.Repositories;
using Confitec.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Infra.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> AddAsync(User user, CancellationToken cancellationToken)
        {
            var createdUser = await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync(cancellationToken);

            return createdUser.Entity;
        }

        public async Task<User> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            var updatedUser = _context.Users.Update(user);

            await _context.SaveChangesAsync(cancellationToken);

            return updatedUser.Entity;
        }

        public async Task DeleteAsync(User user, CancellationToken cancellationToken)
        {
            var result = _context.Remove(user);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
