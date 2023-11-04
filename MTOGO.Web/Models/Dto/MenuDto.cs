using MTOGO.Web.Entities.RestaurantAggregate;

namespace MTOGO.Web.Models.Dto;

public class MenuDto
{
    public List<MenuItemDto> Items { get; set; } = new();
}