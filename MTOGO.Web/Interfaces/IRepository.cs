namespace MTOGO.Web.Interfaces;

public interface IRepository<T> where T : IAggregateRoot
{
    // Implements IAggregateRoot because only entities should have repositories
}