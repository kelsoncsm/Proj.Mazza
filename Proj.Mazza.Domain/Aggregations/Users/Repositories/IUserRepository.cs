using System;
using Proj.Mazza.Domain.Common;

namespace Proj.Mazza.Domain.Aggregations.Users.Repositories
{
    public interface IUserRepository : IWriteRepository<Guid, User>, IReadRepository<Guid, User>
    {
    }
}