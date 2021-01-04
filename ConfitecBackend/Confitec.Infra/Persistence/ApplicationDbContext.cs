using Confitec.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Infra.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Created") != null))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Property("Created").CurrentValue = DateTime.Now;
                        entry.Property("LastModified").CurrentValue = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Property("LastModified").CurrentValue = DateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer();
    }
}
