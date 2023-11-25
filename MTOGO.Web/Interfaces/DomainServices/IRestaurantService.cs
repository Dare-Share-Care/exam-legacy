using MTOGO.Web.Entities.RestaurantAggregate;
using MTOGO.Web.Models.Dto;

namespace MTOGO.Web.Interfaces.DomainServices;

public interface IRestaurantService
{
    Task<RestaurantDto> CreateRestaurantAsync(string name);
    Task<List<MenuItemDto>> GetRestaurantMenuAsync(long restaurantId);
    Task<RestaurantDto> AddMenuItemAsync(long restaurantId, MenuItemDto dto);
    Task<RestaurantDto> RemoveMenuItemAsync(long restaurantId, long menuItemId);
    
    Task<List<RestaurantDto>> GetAllRestaurantsAsync();
    
}