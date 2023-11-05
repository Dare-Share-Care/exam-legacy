using MTOGO.Web.Entities.RestaurantAggregate;
using MTOGO.Web.Models.Dto;

namespace MTOGO.Web.Interfaces.DomainServices;

public interface IRestaurantService
{
    public Task<RestaurantDto> CreateRestaurantAsync(string name);
    public Task<List<MenuItemDto>> GetRestaurantMenu(long restaurantId);
    public Task<RestaurantDto> AddMenuItem(long restaurantId, MenuItemDto dto);
}