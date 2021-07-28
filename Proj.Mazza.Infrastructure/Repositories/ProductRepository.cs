using System;
 
using Proj.Mazza.Domain.Aggregations.Products.Repositories;
using Cyrela.Onboarding.Infrastructure.Data.EF.Repositories.Common;
using Proj.Mazza.Domain.Aggregations.Products;

namespace Cyrela.Onboarding.Infrastructure.Data.EF.Repositories
{
    public sealed class ProductRepository : WriteRepository<Guid, Product>, IProductRepository
    {
        public ProductRepository(OnboardingContext context) : base(context)
        {
        }
    }
}