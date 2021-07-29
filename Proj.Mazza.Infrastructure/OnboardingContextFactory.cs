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
            //optionsBuilder.UseSqlServer(args.First());
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-T9S6CA1\\SQLEXPRESS; Initial Catalog=db-mazza; Integrated Security=True");
            return new OnboardingContext(optionsBuilder.Options);

        }

 
    }
}