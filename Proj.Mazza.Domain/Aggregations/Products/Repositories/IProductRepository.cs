using System;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Proj.Mazza.Domain.Common;

namespace Proj.Mazza.Domain.Aggregations.Products.Repositories
{
    public interface IProductRepository : IWriteRepository<Guid, Product>, IReadRepository<Guid, Product>
    {
    }
}