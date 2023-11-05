using MTOGO.Web.Entities.RestaurantAggregate;
using MTOGO.Web.Interfaces.DomainServices;
using MTOGO.Web.Interfaces.Repositories;
using MTOGO.Web.Models.Dto;
using MTOGO.Web.Specifications;

namespace MTOGO.Web.Services;

public class RestaurantService : IRestaurantService
{
    private readonly IReadRepository<Restaurant> _restaurantReadRepository;

    public RestaurantService(IReadRepository<Restaurant> restaurantReadRepository)
    {
        _restaurantReadRepository = restaurantReadRepository;
    }

    public Task<RestaurantDto> CreateRestaurantAsync(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<List<MenuItemDto>> GetRestaurantMenu(long restaurantId)
    {
        var restaurant =
            await _restaurantReadRepository.FirstOrDefaultAsync(new GetRestaurantWithMenuItemsSpec(restaurantId));
        if (restaurant is null)
        {
            throw new Exception($"Restaurant with id {restaurantId} not found");
        }

        var menu = restaurant.MenuItems.Select(menuItem => new MenuItemDto
        {
            Id = menuItem.Id,
            Name = menuItem.Name,
            Price = menuItem.Price
        }).ToList();

        return menu;
    }
}