using MTOGO.Web.Entities.RestaurantAggregate;
using MTOGO.Web.Exceptions;
using MTOGO.Web.Interfaces.DomainServices;
using MTOGO.Web.Interfaces.Repositories;
using MTOGO.Web.Models.Dto;
using MTOGO.Web.Specifications;

namespace MTOGO.Web.Services;

public class RestaurantService : IRestaurantService
{
    private readonly IReadRepository<Menu> _menuReadRepository;
    private readonly IRepository<Menu> _menuRepository;

    public RestaurantService(IReadRepository<Menu> menuReadRepository, IRepository<Menu> menuRepository)
    {
        _menuReadRepository = menuReadRepository;
        _menuRepository = menuRepository;
    }

    public async Task<MenuDto> GetMenu(long restaurantId)
    {
        var menu = await _menuReadRepository.FirstOrDefaultAsync(new GetMenuByRestaurantIdSpec(restaurantId));

        // Null check
        if (menu == null) throw new MenuNotFoundException(restaurantId);
    
        // Map MenuItem entities to MenuItemDto objects with only the Name property
        var menuItemDtos = menu.Items.Select(item => new MenuItemDto { Name = item.Name, Pricing = {Id = item.Pricing.Id, Price = item.Pricing.Price} }).ToList();

        // Create MenuDto with the mapped MenuItemDtos
        var menuDto = new MenuDto { Items = menuItemDtos };    
        return menuDto;
    }

    public async Task<MenuDto> CreateMenu(long restaurantId, MenuDto menuDto)
    {
        
        
        // Create new Menu entity
        var newMenu = new Menu { RestaurantId = restaurantId, Items = menuDto.Items.Select(item => new MenuItem { Name = item.Name }).ToList() };

        //TODO add check for existing menu on restaurant
        
        
        
        var createdMenu = await _menuRepository.AddAsync(newMenu);
        await _menuRepository.SaveChangesAsync();
        var createdMenuDto = new MenuDto { Items = createdMenu.Items.Select(item => new MenuItemDto { Name = item.Name, Pricing = {Id = item.Pricing.Id, Price = item.Pricing.Price} }).ToList() };
        return createdMenuDto;
    }
}