using System;
 
using Proj.Mazza.Domain.Aggregations.Products.Repositories;
using Cyrela.Onboarding.Infrastructure.Data.EF.Repositories.Common;
using Proj.Mazza.Domain.Aggregations.Products;
using Proj.Mazza.Domain.Aggregations.Users;
using Proj.Mazza.Domain.Aggregations.Users.Repositories;

namespace Cyrela.Onboarding.Infrastructure.Data.EF.Repositories
{
    public sealed class UserRepository : WriteRepository<Guid, User>, IUserRepository
    {
        public UserRepository(OnboardingContext context) : base(context)
        {
        }
    }
}