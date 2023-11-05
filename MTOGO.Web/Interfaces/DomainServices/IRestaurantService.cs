using MTOGO.Web.Entities.RestaurantAggregate;
using MTOGO.Web.Models.Dto;

namespace MTOGO.Web.Interfaces.DomainServices;

public interface IRestaurantService
{
    public Task<MenuDto> GetMenu(long restaurantId);
    
    public Task<MenuDto> CreateMenu(long restaurantId, MenuDto menuDto);
}