using Ardalis.Specification;
using MTOGO.Web.Entities.RestaurantAggregate;

namespace MTOGO.Web.Specifications;

public sealed class GetRestaurantWithMenuItemsSpec : Specification<Restaurant>
{
    public GetRestaurantWithMenuItemsSpec(long restaurantId)
    {
        Query.Where(res => res.Id == restaurantId)
            .Include(res => res.MenuItems);
    }
}