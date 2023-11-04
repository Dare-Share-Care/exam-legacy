using MTOGO.Web.Entities.RestaurantAggregate;
using MTOGO.Web.Exceptions;
using MTOGO.Web.Interfaces.DomainServices;
using MTOGO.Web.Interfaces.Repositories;
using MTOGO.Web.Models.Dto;
using MTOGO.Web.Specifications;

namespace MTOGO.Web.Services;

public class RestaurantService : IRestaurantService
{
    private readonly IReadRepository<Menu> _menuRepository;

    public RestaurantService(IReadRepository<Menu> menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<MenuDto> GetMenu(long restaurantId)
    {
        var menu = await _menuRepository.FirstOrDefaultAsync(new GetMenuByRestaurantIdSpec(restaurantId));

        // Null check
        if (menu == null) throw new MenuNotFoundException(restaurantId);
    
        // Map MenuItem entities to MenuItemDto objects with only the Name property
        var menuItemDtos = menu.Items.Select(item => new MenuItemDto { Name = item.Name, Price = item.Pricing.Price }).ToList();

        // Create MenuDto with the mapped MenuItemDtos
        var menuDto = new MenuDto { Items = menuItemDtos };    
        return menuDto;
    }



}