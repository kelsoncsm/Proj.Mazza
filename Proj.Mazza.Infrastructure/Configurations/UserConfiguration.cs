 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proj.Mazza.Domain.Aggregations.Products;
using Proj.Mazza.Domain.Aggregations.Users;

namespace Cyrela.Onboarding.Infrastructure.Data.EF.Configurations
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", OnboardingContext.SCHEMA);

            builder.Property(p => p.Mail).HasColumnType("VARCHAR(100)");
            builder.Property(p => p.Password).HasColumnType("VARCHAR(100)");
            builder.Property(p => p.CreatedAt);
            builder.Property(p => p.UpdatedAt);

        }
    }
}