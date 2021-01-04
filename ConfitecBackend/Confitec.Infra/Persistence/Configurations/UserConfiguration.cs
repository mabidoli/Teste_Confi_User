using Confitec.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confitec.Infra.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(t => t.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.LastName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.EmailAddress)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.BirthDate)
                .IsRequired();

            builder.Property(t => t.EducationLevel)
                .IsRequired();
        }
    }
}