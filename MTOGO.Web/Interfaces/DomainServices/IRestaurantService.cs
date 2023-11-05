using MTOGO.Web.Entities.RestaurantAggregate;
using MTOGO.Web.Models.Dto;

namespace MTOGO.Web.Interfaces.DomainServices;

public interface IRestaurantService
{
    public Task<RestaurantDto> CreateRestaurantAsync(string name);
    public Task<List<MenuItemDto>> GetRestaurantMenuAsync(long restaurantId);
    public Task<RestaurantDto> AddMenuItemAsync(long restaurantId, MenuItemDto dto);
    public Task<RestaurantDto> RemoveMenuItemAsync(long restaurantId, long menuItemId);
    
    public Task<List<RestaurantDto>> GetAllRestaurantsAsync();
    
}