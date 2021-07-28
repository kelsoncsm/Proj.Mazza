using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Cyrela.Onboarding.Infrastructure.Data.EF
{
    public sealed class OnboardingContextFactory : IDesignTimeDbContextFactory<OnboardingContext>
    {
        public OnboardingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OnboardingContext>();
            optionsBuilder.UseSqlServer(args.First());
            return new OnboardingContext(optionsBuilder.Options);

        }
    }
}