using MTOGO.Web.Entities.RestaurantAggregate;
using MTOGO.Web.Interfaces.DomainServices;
using MTOGO.Web.Interfaces.Repositories;
using MTOGO.Web.Models.Dto;
using MTOGO.Web.Specifications;

namespace MTOGO.Web.Services;

public class RestaurantService : IRestaurantService
{
    private readonly IReadRepository<Restaurant> _restaurantReadRepository;
    private readonly IRepository<Restaurant> _restaurantRepository;

    public RestaurantService(IReadRepository<Restaurant> restaurantReadRepository,
        IRepository<Restaurant> restaurantRepository)
    {
        _restaurantReadRepository = restaurantReadRepository;
        _restaurantRepository = restaurantRepository;
    }

    public async Task<RestaurantDto> CreateRestaurantAsync(string name)
    {
        var createdRestaurant = await _restaurantRepository.AddAsync(new Restaurant { Name = name });

        var restaurantDto = new RestaurantDto
        {
            Id = createdRestaurant.Id,
            Name = createdRestaurant.Name
        };
        return restaurantDto;
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