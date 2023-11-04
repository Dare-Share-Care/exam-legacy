using MTOGO.Web.Interfaces;

namespace MTOGO.Web.Repositories;

public class RepositoryBase<T> : IRepository<T> where T : IAggregateRoot
{
    // This is a generic repository meant to be used by all other repositories for basic CRUD operations
}