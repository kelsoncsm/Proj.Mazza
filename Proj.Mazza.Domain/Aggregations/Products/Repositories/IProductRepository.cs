using System;
using Proj.Mazza.Domain.Common;

namespace Proj.Mazza.Domain.Aggregations.Products.Repositories
{
    public interface IProductRepository : IWriteRepository<Guid, Product>, IReadRepository<Guid, Product>
    {
    }
}