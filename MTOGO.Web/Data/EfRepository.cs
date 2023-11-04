using Ardalis.Specification.EntityFrameworkCore;
using MTOGO.Web.Interfaces.Repositories;

namespace MTOGO.Web.Data;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class
{
    public readonly MtogoContext MtogoContext;

    public EfRepository(MtogoContext mtogoContext) : base(mtogoContext) =>
        this.MtogoContext = mtogoContext;
}