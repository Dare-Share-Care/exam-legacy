using MTOGO.Web.Entities.RestaurantAggregate;

namespace MTOGO.Web.Interfaces.DomainServices;

public interface IRestaurantService
{
    public Task<Menu> GetMenu(long restaurantId);
}