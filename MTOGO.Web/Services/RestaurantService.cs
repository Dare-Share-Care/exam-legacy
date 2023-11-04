using MTOGO.Web.Entities.RestaurantAggregate;
using MTOGO.Web.Interfaces.DomainServices;

namespace MTOGO.Web.Services;

public class RestaurantService : IRestaurantService
{
    public Task<Menu> GetMenu(long restaurantId)
    {
        throw new NotImplementedException();
    }
}