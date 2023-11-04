using Ardalis.Specification;
using MTOGO.Web.Entities.RestaurantAggregate;

namespace MTOGO.Web.Specifications;

public sealed class GetMenuByRestaurantIdSpec : Specification<Menu>
{
    public GetMenuByRestaurantIdSpec(long restaurantId)
    {
        Query.Where(menu => menu.RestaurantId == restaurantId)
            .Include(menu => menu.Items)
            .ThenInclude(item => item.Pricing);
    }
}