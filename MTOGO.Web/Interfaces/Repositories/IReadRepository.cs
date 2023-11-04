using Ardalis.Specification;

namespace MTOGO.Web.Interfaces.Repositories;

public interface IRepository<T> : IRepositoryBase<T> where T : class
{
}