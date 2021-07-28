 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proj.Mazza.Domain.Aggregations.Products;

namespace Cyrela.Onboarding.Infrastructure.Data.EF.Configurations
{
    public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", OnboardingContext.SCHEMA);

            builder.Property(p => p.Name).HasColumnType("VARCHAR(100)");
            builder.Property(p => p.Category).HasColumnType("SMALLINT");
            builder.Property(p => p.Price).HasColumnType("DECIMAL(18,2)");
            builder.Property(p => p.CreatedAt);
            builder.Property(p => p.UpdatedAt);

        }
    }
}