using Ardalis.Specification;

namespace MTOGO.Web.Interfaces.Repositories;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class
{
}